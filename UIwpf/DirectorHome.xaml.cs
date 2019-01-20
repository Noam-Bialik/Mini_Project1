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

namespace UIwpf
{
    /// <summary>
    /// Interaction logic for DirectorUserControl.xaml
    /// </summary>
    public partial class DirectorHome : UserControl
    {
        public DirectorHome()
        {
            InitializeComponent();
        }

        private void Testrs_Click(object sender, RoutedEventArgs e)
        {
            MainColumn.Content = new AllTesters();            
        }

        private void Trainees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tests_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
