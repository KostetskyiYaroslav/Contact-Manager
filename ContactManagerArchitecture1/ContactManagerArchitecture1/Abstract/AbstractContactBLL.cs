using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Abstract
{
    public interface AbstractContactBLL
    {
        #region Add

        void AddContact(ContactModel model);

        ContactModel AddContactScalar(ContactModel model);

        void AddContactToOtherGroup(ContactModel model);

        #endregion

        #region Update

        void UpdateContact(ContactModel model);

        #endregion

        #region Remove

        void RemoveContact(ContactModel model);

        #endregion

        #region Read

        DataTable ReadCotnact();

        IEnumerable<ContactModel> ReadContactList();

        #endregion

        #region Search

        DataTable SearchContact(ContactModel model);

        #endregion
    }
}
