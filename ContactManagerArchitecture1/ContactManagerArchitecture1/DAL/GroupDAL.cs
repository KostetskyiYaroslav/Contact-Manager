using ContactManagerArchitecture1.Abstract;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.DAL
{
    public class GroupDAL : AbstractGroupDAL
    {

        #region Declaration

        private string GetConnectionString()
        {
            return @"Server=HOME-PC\SQLEXPRESS;Database=25C18_kostecki;Trusted_Connection=True;";
            //return @"Server=10.7.0.5;Database=25C18_kostecki;User Id=sa;Password=itstep;";
        }

        #endregion

        #region Add

        public void AddGroup(GroupModel model)
        {
            SqlConnection connection = new SqlConnection(this.GetConnectionString());

            connection.Open();

            SqlCommand command = connection.CreateCommand();

            string Name = model.Name;
            string Comment = model.Comment;

            StringBuilder sqlQuery = new StringBuilder(999);
            sqlQuery.AppendFormat("INSERT INTO [tblGroup] "
                                + "([Name], [Comment]) "
                                + "VALUES (N'{0}'"
                                , Name);

            if (!String.IsNullOrWhiteSpace(Comment))
            {
                sqlQuery.AppendFormat(", N'{0}'", Comment);
            }
            else
                sqlQuery.Append(", NULL");

            sqlQuery.Append(");");

            command.CommandText = sqlQuery.ToString();

            command.ExecuteNonQuery();

            connection.Close();
        }
        
        public GroupModel AddGroupScalar(GroupModel model)
        {
            SqlConnection connection = new SqlConnection(this.GetConnectionString());

            connection.Open();

            SqlCommand command = connection.CreateCommand();

            string Name = model.Name;
            string Comment = model.Comment;

            StringBuilder sqlQuery = new StringBuilder(999);
            sqlQuery.AppendFormat("INSERT INTO [tblGroup] "
                                + "([Name], [Comment]) "
                                + "VALUES (N'{0}'"
                                , Name);

            if (!String.IsNullOrWhiteSpace(Comment))
            {
                sqlQuery.AppendFormat(", N'{0}'", Comment);
            }
            else
                sqlQuery.Append(", NULL");

            sqlQuery.Append(");");

            command.CommandText = sqlQuery.ToString();

            int AddedId = (int)command.ExecuteScalar();

            connection.Close();

            model.Id = AddedId;

            return model;
        }

        #endregion

        #region Update

        public void UpdateGroup(GroupModel model)
        {
            SqlConnection connection = new SqlConnection(this.GetConnectionString());

            connection.Open();

            SqlCommand command = connection.CreateCommand();

            int UpdateId = model.Id;

            string Name = model.Name;

            string Comment = model.Comment;

            StringBuilder sqlQuery = new StringBuilder(999);

            sqlQuery.Append("UPDATE [tblGroup] SET [Name] = ");

            sqlQuery.AppendFormat("N'{0}'", Name);

            sqlQuery.AppendFormat(", [Comment] = N'{0}'", Comment);

            sqlQuery.AppendFormat("WHERE [IdGroup] = {0};", UpdateId);

            command.CommandText = sqlQuery.ToString();

            command.ExecuteNonQuery();

            connection.Close();
        }
        #endregion

        #region Remove

        public void RemoveGroup(GroupModel model)
        {
            SqlConnection connection = new SqlConnection(this.GetConnectionString());

            connection.Open();

            SqlCommand command = connection.CreateCommand();

            int RemoveId = model.Id;

            StringBuilder sqlQuery = new StringBuilder(999);

            sqlQuery.AppendFormat("DELETE [tblGroup] WHERE [IdGroup] = {0};", RemoveId);

            command.CommandText = sqlQuery.ToString();

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region Read

        public DataTable ReadGroup(int sort = 1)
        {
            SqlConnection connect = new SqlConnection(this.GetConnectionString());

            string sql = "SELECT * FROM [tblGroup] ORDER BY " + sort + ";";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);

            //There Set Data from comming table from Server
            DataTable dataset = new DataTable();

            connect.Open();

            adapter.Fill(dataset);

            //ya x3, Maybe give access to update tran.
            adapter.Update(dataset);

            connect.Close();

            return dataset;
        }

        public IEnumerable<GroupModel> ReadGroupList()
        {
            try
            {

                SqlConnection connect = new SqlConnection(this.GetConnectionString());


                DataTable dataset = new DataTable();

                connect.Open();

                List<GroupModel> GroupList = new List<GroupModel>();

                using (IDbCommand command = connect.CreateCommand())
                {

                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT [Name] FROM [tblGroup];";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            GroupModel group = new GroupModel()
                            {

                                Name = (string)reader["Name"],

                            };

                            GroupList.Add(group);
                        }
                    }

                    connect.Close();

                    return GroupList;

                }

            }

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        #endregion

    }
}
