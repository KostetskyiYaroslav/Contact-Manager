using ContactManagerArchitecture1.Abstract;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerArchitecture1.DAL
{
    public class ContactDAL : AbstractContactDAL
    {

        #region Declaration

        private string GetConnectionString()
        {

            return @"Server=HOME-PC\SQLEXPRESS;Database=25C18_kostecki;Trusted_Connection=True;";
            //return @"Server=10.7.0.5;Database=25C18_kostecki;User Id=sa;Password=itstep;";

        }

        #endregion

        #region Add

        public void AddContact(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                string Phone = model.Phone;
                string FirstName = model.FirstName;
                string LastName = model.LastName;
                string Email = model.Email;
                string Birthday = model.Birthday.Year.ToString() + '/' + model.Birthday.Month.ToString() + '/' + model.Birthday.Day.ToString();

                string Comment = model.Comment;

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.AppendFormat("INSERT INTO [tblContact] ([Phone], [FirstName], [LastName], [Email], [Birthday], [Comment]) VALUES "
                                    + "(N'{0}'", Phone);

                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sqlQuery.AppendFormat(", N'{0}'", FirstName);
                }
                else
                    sqlQuery.Append(", NULL");

                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sqlQuery.AppendFormat(", N'{0}'", LastName);
                }
                else
                    sqlQuery.Append(", NULL");

                if (!String.IsNullOrWhiteSpace(Email))
                {
                    sqlQuery.AppendFormat(", N'{0}'", Email);
                }
                else
                    sqlQuery.Append(", NULL");

                if (!String.IsNullOrWhiteSpace(Birthday) || Birthday.Length > 2)
                {
                    sqlQuery.AppendFormat(", '{0}'", Birthday);
                }
                else
                    sqlQuery.Append(", NULL");

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

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }
        }

        public ContactModel AddContactScalar(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                string Phone = model.Phone;
                string FirstName = model.FirstName;
                string LastName = model.LastName;
                string Email = model.Email;
                string Birthday = model.Birthday.Year.ToString() + '/' + model.Birthday.Month.ToString() + '/' + model.Birthday.Day.ToString();

                string Comment = model.Comment;

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.AppendFormat("INSERT INTO [tblContact] ([Phone], [FirstName], [LastName], [Email], [Birthday], [Comment]) VALUES "
                                    + "(N'{0}'", Phone);

                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sqlQuery.AppendFormat(", N'{0}'", FirstName);
                }
                else
                    sqlQuery.Append(", NULL");

                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sqlQuery.AppendFormat(", N'{0}'", LastName);
                }
                else
                    sqlQuery.Append(", NULL");

                if (!String.IsNullOrWhiteSpace(Email))
                {
                    sqlQuery.AppendFormat(", N'{0}'", Email);
                }
                else
                    sqlQuery.Append(", NULL");

                if (model.Birthday.ToString() != "01.01.0001 0:00:00")
                {
                    sqlQuery.AppendFormat(", '{0}'", Birthday);

                }
                else
                    sqlQuery.Append(", NULL");

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

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        public void AddContactToOtherGroup(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();
                
                string FirstName = model.FirstName;
                string GroupName = model.Group.Name;

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.AppendFormat("INSERT INTO [tblManyToManyRelationship] " 
                                    + "VALUES "
                                    + "( (SELECT [IdContact] FROM [GetContactByName] (N'{0}') ) "
                                    + ", (SELECT [IdGroup] FROM [GetGrouptByName] (N'{1}') ) );"
                                    , FirstName, GroupName);

                command.CommandText = sqlQuery.ToString();

                command.ExecuteNonQuery();

                connection.Close();

            }

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }
        }

        #endregion

        #region Read

        public DataTable ReadCotnact(int sort = 1)
        {
            try
            {

                SqlConnection connect = new SqlConnection(this.GetConnectionString());

                string sql = "SELECT * FROM GetAllContact() ORDER BY " + sort + ";";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);

                DataTable dataset = new DataTable();

                connect.Open();

                adapter.Fill(dataset);

                adapter.Update(dataset);

                connect.Close();

                return dataset;
            }
            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        public IEnumerable<ContactModel> ReadContactList()
        {
            try
            {

                SqlConnection connect = new SqlConnection(this.GetConnectionString());


                DataTable dataset = new DataTable();

                connect.Open();

                List<ContactModel> ContactList = new List<ContactModel>();

                using (IDbCommand command = connect.CreateCommand())
                {

                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT [FirstName] FROM [tblContact];";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ContactModel contact = new ContactModel
                            {

                                FirstName = (string)reader["FirstName"],

                            };

                            ContactList.Add(contact);
                        }
                    }

                    connect.Close();

                    return ContactList;

                }

            }

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        #endregion

        #region Update

        public void UpdateContact(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                int UpdateId = model.Id;

                string Phone = model.Phone;
                string FirstName = model.FirstName;
                string LastName = model.LastName;
                string Email = model.Email;
                string Birthday = model.Birthday.Year.ToString() + '/' + model.Birthday.Month.ToString() + '/' + model.Birthday.Day.ToString();
                string Comment = model.Comment;

                string GroupName = model.Group.Name;

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.Append("UPDATE [tblContact] SET [Phone] = ");

                sqlQuery.AppendFormat(" N'{0}'", Phone);
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sqlQuery.AppendFormat(", [FirstName] = N'{0}'", FirstName);
                }

                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sqlQuery.AppendFormat(", [LastName] = N'{0}'", LastName);
                }
                else
                    sqlQuery.Append(", [LastName] = NULL");


                if (!String.IsNullOrWhiteSpace(Email))
                {
                    sqlQuery.AppendFormat(", [Email] = N'{0}'", Email);
                }
                else
                    sqlQuery.Append(", [Email] = NULL");


                if (Birthday != "0001/01/01" || !String.IsNullOrWhiteSpace(Birthday))
                {
                    sqlQuery.AppendFormat(", [Birthday] = '{0}'", Birthday);
                }
                else
                    sqlQuery.Append(", [Birthday] = NULL");


                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sqlQuery.AppendFormat(", [Comment] = N'{0}' ", Comment);
                }
                else
                    sqlQuery.Append(", [Comment] = NULL ");

                sqlQuery.AppendFormat("WHERE [IdContact] = '{0}';", UpdateId);

                command.CommandText = sqlQuery.ToString();

                model.Id = (int)command.ExecuteScalar();

                connection.Close();

                if (!String.IsNullOrWhiteSpace(GroupName))
                {
                    this.UpdateContactGroup(model);
                }
            }

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        public void UpdateContactGroup(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                int IdContact = model.Id;

                string GroupName = model.Group.Name;

                string sqlIdGroup = String.Format("SELECT * FROM GetGrouptByName (N'{0}')", GroupName);

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.AppendFormat("UPDATE [tblManyToManyRelationship] "
                                    + "SET [IdGroup] = ({0}) "
                                    + "WHERE [IdContact] = {1};",
                    sqlIdGroup, IdContact);

                command.CommandText = sqlQuery.ToString();

                command.ExecuteNonQuery();

                connection.Close();

            }

            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }

        }

        #endregion

        #region Remove

        public void RemoveContact(ContactModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.GetConnectionString());

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                int RemoveId = model.Id;

                StringBuilder sqlQuery = new StringBuilder(999);

                sqlQuery.AppendFormat("DELETE [tblContact] WHERE [IdContact] = {0};", RemoveId);

                command.CommandText = sqlQuery.ToString();

                command.ExecuteNonQuery();

                connection.Close();
            }

            catch(Exception eRemove)
            {
                throw new InvalidProgramException(eRemove.Message);
            }
        }

        #endregion

        #region Search

        public DataTable SearchContact(ContactModel model)
        {
            try
            {
                string FirstName = model.FirstName;
                string Phone = model.Phone;
                string GroupName = model.Group.Name;

                SqlConnection connect = new SqlConnection(this.GetConnectionString());

                StringBuilder sqlQuery = new StringBuilder(999);

                StringBuilder sqlQueryWhere = new StringBuilder(999);

                sqlQuery.Append("SELECT * FROM GetAllContact() WHERE");

                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sqlQueryWhere.AppendFormat(" [FirstName] LIKE N'{0}%'", FirstName);
                }

                if (!String.IsNullOrWhiteSpace(Phone) && String.IsNullOrWhiteSpace(sqlQueryWhere.ToString()))
                {
                    sqlQueryWhere.AppendFormat(" [Phone] LIKE N'{0}%'", Phone);
                }
                else if (!String.IsNullOrWhiteSpace(Phone) && !String.IsNullOrWhiteSpace(sqlQueryWhere.ToString()))
                {
                    sqlQueryWhere.AppendFormat(" OR [Phone] LIKE N'{0}%'", Phone);
                }

                if (!String.IsNullOrWhiteSpace(GroupName) && String.IsNullOrWhiteSpace(sqlQueryWhere.ToString()))
                {
                    sqlQueryWhere.AppendFormat(" [GroupName] LIKE N'{0}%'", GroupName);
                }
                else if (!String.IsNullOrWhiteSpace(GroupName) && !String.IsNullOrWhiteSpace(sqlQueryWhere.ToString()))
                {
                    sqlQueryWhere.AppendFormat(" OR [GroupName] LIKE N'{0}%'", GroupName);
                }

                sqlQueryWhere.Append(";");

                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery.ToString() + sqlQueryWhere.ToString(), connect);

                DataTable dataset = new DataTable();

                connect.Open();

                adapter.Fill(dataset);

                adapter.Update(dataset);

                connect.Close();

                return dataset;
            }
            catch(Exception eSearchContact)
            {
                throw new InvalidProgramException(eSearchContact.Message);
            }

        }

        #endregion
    }
}
