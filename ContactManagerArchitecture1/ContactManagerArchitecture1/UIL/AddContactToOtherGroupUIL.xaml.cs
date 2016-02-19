using ContactManagerArchitecture1.BLL;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManagerArchitecture1.UIL
{
    /// <summary>
    /// Interaction logic for AddContactToOtherGroupUIL.xaml
    /// </summary>
    public partial class AddContactToOtherGroupUIL : UserControl
    {
        ContactBLL ContactBLL = null;
        GroupBLL GroupBLL = null;

        public AddContactToOtherGroupUIL()
        {
            InitializeComponent();
            this.ContactBLL = new ContactBLL();
            this.GroupBLL = new GroupBLL();
        }

        private void ContactList_CB_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContactList_CB.Items.Clear();
            try
            {
                foreach (ContactModel contact in this.ContactBLL.ReadContactList())
                {
                    this.ContactList_CB.Items.Add(contact.FirstName);
                }
            }

            catch (Exception eGetContactName)
            {
                MessageBox.Show(eGetContactName.Message);
            }
        }

        private void GroupList_CB_Loaded(object sender, RoutedEventArgs e)
        {
            this.GroupList_CB.Items.Clear();
            try
            {
                foreach (GroupModel group in this.GroupBLL.ReadGroupList())
                {
                    this.GroupList_CB.Items.Add(group.Name);
                }
            }

            catch (Exception eGetGroupName)
            {
                MessageBox.Show(eGetGroupName.Message);
            }
        }

        private void AddGroupRelation_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactModel model = new ContactModel
                {
                    FirstName = this.ContactList_CB.SelectedValue.ToString(),
                    Group = new GroupModel
                    {
                        Name = this.GroupList_CB.SelectedValue.ToString()
                    }
                };

                this.ContactBLL.AddContactToOtherGroup(model);
            }

            catch (Exception eAddGroupRelation)
            {
                MessageBox.Show(eAddGroupRelation.Message);
            }
        }
    }
}
