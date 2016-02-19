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
    /// Interaction logic for AddGroupUIL.xaml
    /// </summary>
    public partial class AddGroupUIL : UserControl
    {
        private GroupBLL BLL;
        public AddGroupUIL()
        {
            InitializeComponent();
            this.BLL = new GroupBLL();
        }

        private void AddGroup_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.BLL.AddGroup(
                    new GroupModel 
                    {
                        Name = this.NewGroupName_TB.Text,
                        Comment = this.NewGroupComment_TB.Text
                    }
                );
                this.UnsetText();
            }
            catch(Exception eAddGroup)
            {
                MessageBox.Show(eAddGroup.Message);
            }
        }

        private void UnsetText() 
        {
            this.NewGroupName_TB.Text = "";
            this.NewGroupComment_TB.Text = "";
        }
    }
}
