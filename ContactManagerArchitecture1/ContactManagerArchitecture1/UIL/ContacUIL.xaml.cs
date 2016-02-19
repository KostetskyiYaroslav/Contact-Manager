using ContactManagerArchitecture1.BLL;
using ContactManagerArchitecture1.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ContacUIL.xaml
    /// </summary>
    public partial class ContacUIL : UserControl
    {

        ContactBLL BLL;

        public ContacUIL()
        {
            InitializeComponent();
            this.BLL = new ContactBLL();
            this.ReadContact();

        }

        private void ReadContact()
        {

            try
            {

                this.CotnactTable_DG.ItemsSource = this.BLL.ReadCotnact().DefaultView;

            }

            catch (Exception eReadContact)
            {

                MessageBox.Show(eReadContact.Message);

            }

        }

        private void CotnactTable_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (this.CotnactTable_DG.IsReadOnly)
            {

                this.CotnactTable_DG.IsReadOnly = false;

                this.UpdateButton_B.Visibility = Visibility.Visible;
                this.DeleteButton_B.Visibility = Visibility.Visible;
                this.ExitEditMod_B.Visibility = Visibility.Visible;

            }

        }

        private void UpdateButton_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.BLL.UpdateContact(this.GetSelectedContact());

                this.ReadContact();
            }

            catch (Exception eDeleteContact)
            {
                MessageBox.Show("ERROR: " + eDeleteContact.Message);
            }
        }

        private void DeleteButton_B_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Do you really want to delete this Contact?", "Confirmation",
                                                             MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {

                int RemoveId = this.GetSelectedId();

                try
                {
                    this.BLL.RemoveContact(new ContactModel
                    {
                        Id = RemoveId
                    });

                    this.ReadContact();

                    MessageBox.Show("Contact was successfully deleted!");
                }

                catch (Exception eDeleteContact)
                {
                    MessageBox.Show("ERROR: " + eDeleteContact.Message);
                }

            }

            else
                MessageBox.Show("Choice was cancel!");
        }

        private int GetSelectedId()
        {

            foreach (DataRowView row in CotnactTable_DG.SelectedItems)
            {
                return (int)row[0];
            }

            return 0;
        }

        private ContactModel GetSelectedContact()
        {

            foreach (DataRowView row in CotnactTable_DG.SelectedItems)
            {

                ContactModel model = new ContactModel
                {
                    Id = (int)row[0],
                    Phone = (string)row[1],
                    FirstName = (string)row[2],
                    LastName = (string)row[3],
                    Email = (string)row[4],
                    Birthday = (DateTime)row[5],
                    Comment = (string)row[6],
                    Group = new GroupModel { Name = (string)row[8] }
                };

                return model;
            }

            return null;
        }

        private void CotnactTable_DG_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                this.ReadContact();

            }

            catch (Exception eReadContact)
            {

                MessageBox.Show(eReadContact.Message);

            }
        }

        private void ExitEditMod_B_Click(object sender, RoutedEventArgs e)
        {

            if (!this.CotnactTable_DG.IsReadOnly)
            {

                this.CotnactTable_DG.IsReadOnly = true;

                this.UpdateButton_B.Visibility = Visibility.Hidden;
                this.DeleteButton_B.Visibility = Visibility.Hidden;
                this.ExitEditMod_B.Visibility = Visibility.Hidden;

            }

        }

        private void AddGroupButton_B_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
