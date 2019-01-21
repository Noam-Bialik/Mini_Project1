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
using BE;
using BL;
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for RemoveTester.xaml
    /// </summary>
    public partial class RemoveTester : UserControl
    {
        string id;
        public RemoveTester(string tester_id)
        {
            InitializeComponent();
            id = tester_id;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Ibl help = FactoryBL.GetInstance();
            try
            {
                help.RemoveTester(id);
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Visibility = Visibility.Collapsed;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
