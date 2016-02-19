using ContactManagerArchitecture1.Abstract;
using ContactManagerArchitecture1.DAL;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerArchitecture1.BLL
{
    public class GroupBLL : AbstractGroupBLL
    {
        #region Declaretion
        GroupDAL DAL = new GroupDAL();
        #endregion

        #region Add

        public void AddGroup(GroupModel model)
        {
            try
            {
                DAL.AddGroup(model);
            }
            catch (Exception eAddGroup)
            {
                throw new InvalidProgramException(eAddGroup.Message);
            }
        }

        public GroupModel AddGroupScalar(GroupModel model)
        {
            try
            {
                return DAL.AddGroupScalar(model);
            }
            catch (Exception eAddGroup)
            { 
                throw new InvalidProgramException(eAddGroup.Message);
            }
        }

        #endregion

        #region Update

        public void UpdateGroup(GroupModel model)
        {
            try
            {
                DAL.UpdateGroup(model);
            }
            catch (Exception eUpdateContact)
            {
                throw new InvalidProgramException(eUpdateContact.Message);
            }
        }

        #endregion

        #region Remove

        public void RemoveGroup(GroupModel model)
        {
            try
            {
                DAL.RemoveGroup(model);
            }
            catch (Exception eRemove)
            {
                throw new InvalidProgramException(eRemove.Message);
            }
        }

        #endregion

        #region Read

        public DataTable ReadGroup()
        {
            try
            {
                return DAL.ReadGroup();
            }
            catch (Exception eRead)
            {
                throw new InvalidProgramException(eRead.Message);
            }
        }

        public IEnumerable<GroupModel> ReadGroupList()
        {
            try
            {
                return DAL.ReadGroupList();
            }
            catch (Exception eReadGroupList)
            {
                throw new InvalidProgramException(eReadGroupList.Message);
            }
        }

        #endregion
    }
}
