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
    /// Interaction logic for GroupUIL.xaml
    /// </summary>
    public partial class GroupUIL : UserControl
    {
        GroupBLL BLL;
        public GroupUIL()
        {
            InitializeComponent();

            this.BLL = new GroupBLL();

            this.ReadGroup();

        }

        private void ReadGroup()
        {

            this.GroupTable_DG.ItemsSource = BLL.ReadGroup().DefaultView;

        }

        private void GroupTable_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (this.GroupTable_DG.IsReadOnly)
            {
                this.GroupTable_DG.IsReadOnly = false;
            }

        }

        private void UpdateButton_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.BLL.UpdateGroup(this.GetSelectedGroup());

                this.ReadGroup();
            }

            catch (Exception eDeleteContact)
            {
                MessageBox.Show("ERROR: " + eDeleteContact.Message);
            }
        }

        private void DeleteButton_B_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult confirmation = MessageBox.Show("Do you really want to delete this Contact?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {

                int RemoveId = this.GetSelectedId();

                this.BLL.RemoveGroup(new GroupModel
                {
                    Id = RemoveId

                });

                this.ReadGroup();

                MessageBox.Show("Contact was successfully deleted!");
            }
            else
                MessageBox.Show("Choice was cancel!");
        }

        private int GetSelectedId()
        {

            foreach (DataRowView row in this.GroupTable_DG.SelectedItems)
            {
                return (int)row[0];
            }

            return 0;
        }
        private GroupModel GetSelectedGroup()
        {

            foreach (DataRowView row in this.GroupTable_DG.SelectedItems)
            {

                GroupModel model = new GroupModel
                {
                    Id = (int)row[0],
                    Name = (string)row[1],
                    Comment = (string)row[2]
                };

                return model;
            }

            return null;
        }


        private void GroupTable_DG_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReadGroup();
        }

        private void ExitEditMod_B_Click(object sender, RoutedEventArgs e)
        {
            if (!this.GroupTable_DG.IsReadOnly)
            {

                this.GroupTable_DG.IsReadOnly = true;

                this.UpdateButton_B.Visibility = Visibility.Hidden;
                this.DeleteButton_B.Visibility = Visibility.Hidden;
                this.ExitEditMod_B.Visibility = Visibility.Hidden;

            }
        }

        private void GroupTable_DG_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (this.GroupTable_DG.IsReadOnly)
            {

                this.GroupTable_DG.IsReadOnly = false;

                this.UpdateButton_B.Visibility = Visibility.Visible;
                this.DeleteButton_B.Visibility = Visibility.Visible;
                this.ExitEditMod_B.Visibility = Visibility.Visible;

            }
        }

    }
}
