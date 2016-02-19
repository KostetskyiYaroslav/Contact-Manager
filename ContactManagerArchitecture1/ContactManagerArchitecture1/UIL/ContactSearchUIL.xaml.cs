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
    /// Interaction logic for ContactSearchUIL.xaml
    /// </summary>
    public partial class ContactSearchUIL : UserControl
    {
        ContactBLL BLL = null;
        public ContactSearchUIL()
        {
            InitializeComponent();
            this.BLL = new ContactBLL();
        }

        private void SearchTemp() {

            if (this.SearchPhone_TB.Text.Length > 1 || this.SearchName_TB.Text.Length > 1 || this.SearchGroup_TB.Text.Length > 1)
            {
                this.SearchTable_DG.ItemsSource = this.BLL.SearchContact(new ContactModel { 
                    FirstName = this.SearchName_TB.Text, 
                    Phone = this.SearchPhone_TB.Text, 
                    Group = new GroupModel { 
                        Name = this.SearchGroup_TB.Text 
                    } 
                }).DefaultView;
            }
        }
        private void SearchPhone_TB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.SearchTemp();
        }

        private void SearchName_TB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.SearchTemp();

        }

        private void SearchGroup_TB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.SearchTemp();
        }
    }
}
