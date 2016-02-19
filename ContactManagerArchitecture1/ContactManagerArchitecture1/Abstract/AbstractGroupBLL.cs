using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Abstract
{
    public interface AbstractGroupBLL
    {
        #region Add

        void AddGroup(GroupModel model);

        GroupModel AddGroupScalar(GroupModel model);
        
        #endregion

        #region Update

        void UpdateGroup(GroupModel model);
        
        #endregion

        #region Remove

        void RemoveGroup(GroupModel model);
        
        #endregion

        #region Read

        DataTable ReadGroup();

        IEnumerable<GroupModel> ReadGroupList();
        
        #endregion
    }
}
