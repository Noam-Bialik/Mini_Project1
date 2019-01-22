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
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for TesterHome.xaml
    /// </summary>
    public partial class TesterHome : UserControl
    {
        Tester tester;
        UpdateTester updateTester;
        RemoveTester removeTester;
        UpdateTestByTester updateTest;
        AllTesterTests allTests;
        public TesterHome(Tester tester)
        {
            InitializeComponent();
            this.tester = new Tester(tester);
        }

        public event EventHandler LogOutRequest; 

        private void deleted(object sender, EventArgs e)
        {
            LogOutRequest(this, e);
        }

        private void UpdateTester_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {

            }
            updateTester = new UpdateTester(tester);
            data.Children.Add(updateTester);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {

            }
            removeTester = new RemoveTester(tester.Id);
            removeTester.the_tester_deleted += deleted;
            data.Children.Add(removeTester);
        }

        private void UpdateTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {

            }
            updateTest = new UpdateTestByTester(tester);
            data.Children.Add(updateTest);
        }

        private void AllTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {

            }
            allTests = new AllTesterTests(tester);
            data.Children.Add(allTests);
        }
    }
}
