using ContactManagerArchitecture1.BLL;
using ContactManagerArchitecture1.Model;
using ContactManagerArchitecture1.Validation;
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
    /// Interaction logic for AddContactUIL.xaml
    /// </summary>
    public partial class AddContactUIL : UserControl
    {
        ContactBLL ContactBLL = null;
        GroupBLL GroupBLL = null;
        ContactValidation Validation = null;

        public AddContactUIL()
        {
            InitializeComponent();
            this.ContactBLL = new ContactBLL();
            this.GroupBLL = new GroupBLL();
            this.Validation = new ContactValidation();
        }

        private void AddContact_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string Phone = this.NewContactPhone_TB.Text;

                if (this.Validation.ValidatePhone(Phone))
                {
                    this.NewContactPhone_TB.BorderBrush = Brushes.Green;
                }
                else
                    this.NewContactPhone_TB.BorderBrush = Brushes.Red;

                string FirstName = this.NewContactFirstName_TB.Text;

                if (this.Validation.ValidateName(FirstName))
                {
                    this.NewContactFirstName_TB.BorderBrush = Brushes.Green;
                }
                else
                    this.NewContactFirstName_TB.BorderBrush = Brushes.Red;

                string LastName = this.NewContactLastName_TB.Text;

                string Email = this.NewContactEmail_TB.Text;

                if (this.Validation.ValidateEmail(Email))
                {
                    this.NewContactEmail_TB.BorderBrush = Brushes.Green;
                }
                else
                    this.NewContactEmail_TB.BorderBrush = Brushes.Red;

                DateTime Birthday = this.Validation.ValidateBirthday(this.NewContactBirthdayYear_TB.Text.ToString()
                    , this.NewContactBirthdayMonth_TB.Text.ToString()
                    , this.NewContactBirthdayDay_TB.Text.ToString());

                if (Birthday.ToString("dd-MM-yyyy") != "01-01-0001")
                {
                    this.NewContactBirthdayYear_TB.BorderBrush = Brushes.Green;
                    this.NewContactBirthdayMonth_TB.BorderBrush = Brushes.Green;
                    this.NewContactBirthdayDay_TB.BorderBrush = Brushes.Green;
                }

                string Comment = this.NewContactComment_TB.Text;

                GroupModel Group = new GroupModel { Name = "" };

                if (this.GroupNameList_CB.SelectedIndex >= 0)
                {
                    Group = this.Validation.ValidateGroup(this.GroupNameList_CB.SelectedValue.ToString());
                }

                if (this.Validation.ValidateName(FirstName) && this.Validation.ValidateEmail(Email))
                {
                    try
                    {

                        this.ContactBLL.AddContact(new ContactModel
                        {
                            Phone = Phone,
                            FirstName = FirstName,
                            LastName = LastName,
                            Email = Email,
                            Birthday = Birthday,
                            Comment = Comment,
                            Group = Group
                        });

                        this.UntextFilds();
                        this.LoadGroupList();

                        MessageBox.Show("Contact was successfully added!");

                    }
                    catch (Exception eAddContact)
                    {
                        MessageBox.Show(eAddContact.Message);
                    }
                }


                else
                {
                    throw new InvalidProgramException("ERROR: Some data invalid!");
                }

            }

            catch (Exception eAddContact)
            {
                MessageBox.Show(eAddContact.Message);
            }
        }

        private void UntextFilds()
        {
            this.NewContactPhone_TB.Text = "";
            this.NewContactBirthdayYear_TB.Text = "";
            this.NewContactBirthdayMonth_TB.Text = "";
            this.NewContactBirthdayDay_TB.Text = "";
            this.NewContactComment_TB.Text = "";
            this.NewContactEmail_TB.Text = "";
            this.NewContactFirstName_TB.Text = "";
            this.NewContactLastName_TB.Text = "";

            this.NewContactPhone_TB.BorderBrush = Brushes.Gray;
            this.NewContactBirthdayYear_TB.BorderBrush = Brushes.Gray;
            this.NewContactBirthdayMonth_TB.BorderBrush = Brushes.Gray;
            this.NewContactBirthdayDay_TB.BorderBrush = Brushes.Gray;
            this.NewContactComment_TB.BorderBrush = Brushes.Gray;
            this.NewContactEmail_TB.BorderBrush = Brushes.Gray;
            this.NewContactFirstName_TB.BorderBrush = Brushes.Gray;
            this.NewContactLastName_TB.BorderBrush = Brushes.Gray;
        }

        private void LoadGroupList() {
            this.GroupNameList_CB.Items.Clear();
            try
            {
                foreach (GroupModel group in this.GroupBLL.ReadGroupList())
                {
                    this.GroupNameList_CB.Items.Add(group.Name);
                }
            }

            catch (Exception eGetGroupName)
            {
                MessageBox.Show(eGetGroupName.Message);
            }
        }

        private void GroupNameList_CB_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadGroupList();
        }

    }
}
