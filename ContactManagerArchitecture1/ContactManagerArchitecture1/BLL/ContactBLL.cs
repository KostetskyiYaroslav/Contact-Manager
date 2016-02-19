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
    public class ContactBLL : AbstractContactBLL
    {
        #region Declaretion

        ContactDAL DAL = new ContactDAL();

        #endregion

        #region Add

        public void AddContact(ContactModel model)
        {

            try
            {

                if (String.IsNullOrWhiteSpace(model.Group.Name))
                {
                    DAL.AddContact(model);
                }
                else
                    DAL.UpdateContactGroup(DAL.AddContactScalar(model));

            }

            catch (Exception eAddContact)
            {

                throw new InvalidProgramException(eAddContact.Message);

            }

        }

        public ContactModel AddContactScalar(ContactModel model)
        {

            try
            {

                return DAL.AddContactScalar(model);

            }

            catch(Exception eAdd)
            {

                throw new InvalidProgramException(eAdd.Message);

            }

        }

        public void AddContactToOtherGroup(ContactModel model)
        {
            try
            {
                this.DAL.AddContactToOtherGroup(model);
            }
            catch (Exception eAddContactToOtherGroup)
            {
                throw new InvalidProgramException(eAddContactToOtherGroup.Message);
            }
        }

        #endregion

        #region Update

        public void UpdateContact(ContactModel model)
        {

            try
            {

                DAL.UpdateContact(model);

            }

            catch(Exception eUpdate)
            {

                throw new InvalidProgramException(eUpdate.Message);

            }

        }

        #endregion

        #region Remove

        public void RemoveContact(ContactModel model)
        {

            try
            {

                DAL.RemoveContact(model);

            }

            catch (Exception eRemove)
            {

                throw new InvalidProgramException(eRemove.Message);

            }

        }

        #endregion

        #region Read

        public DataTable ReadCotnact()
        {
            try
            {
                return DAL.ReadCotnact();
            }
            catch(Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }
        }

        public IEnumerable<ContactModel> ReadContactList()
        {
            try
            {
                return DAL.ReadContactList();
            }
            catch (Exception e)
            {
                throw new InvalidProgramException(e.Message);
            }
        }

        #endregion

        #region Search
        public DataTable SearchContact(ContactModel model)
        {
            try
            {
                return this.DAL.SearchContact(model);
            }
            catch (Exception eSearContact)
            {
                throw new InvalidProgramException(eSearContact.Message);
            }
        }
        #endregion
    }
}
