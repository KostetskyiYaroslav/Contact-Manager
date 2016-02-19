using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerArchitecture1.Abstract
{
    public interface AbstractContactDAL
    {
        #region Add
        
        void AddContact(ContactModel model);

        ContactModel AddContactScalar(ContactModel model);

        void AddContactToOtherGroup(ContactModel model);

        #endregion

        #region Read

        DataTable ReadCotnact(int sort = 1);

        IEnumerable<ContactModel> ReadContactList();

        #endregion

        #region Update

        void UpdateContact(ContactModel model);

        void UpdateContactGroup(ContactModel model);
        
        #endregion

        #region Remove

        void RemoveContact(ContactModel model);

        #endregion

        #region Search

        DataTable SearchContact(ContactModel model);

        #endregion
    }
}
