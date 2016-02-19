using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Abstract
{
    public interface AbstractGroupDAL
    {
        void AddGroup(GroupModel model);

        GroupModel AddGroupScalar(GroupModel model);

        void UpdateGroup(GroupModel model);

        void RemoveGroup(GroupModel model);

        DataTable ReadGroup(int sort = 1);

    }
}
