using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BL;
using BE;
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for UpdateTestByTester.xaml
    /// </summary>
    public partial class UpdateTestByTester : UserControl
    {
        Tester tester;
        ObservableCollection<Test> obs;
        public UpdateTestByTester(Tester source)
        {
            tester = new Tester(source);
            InitializeComponent();

            Ibl help = FactoryBL.GetInstance();
            obs = new ObservableCollection<Test>(help.GetTests(t => t.Tester_id == tester.Id));
            AllTesterTest.DataContext = obs;

            Note.TextChanged += IsEnabled_Update_Click;
            Grade.TextChanged += IsEnabled_Update_Click;

        }

        private void AllTesterTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = e.AddedItems;
            foreach (var item in x)
            {
                Test help = (Test)item;
                TestId.Text = help.Test_id.ToString();
                Grade.Text = (-1).ToString();
                Note.Text = "";
                UpdateInfo.Visibility = Visibility.Visible;
                return;
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Ibl help = FactoryBL.GetInstance();
            try
            {
                help.UpdateTest(long.Parse(TestId.Text), int.Parse(Grade.Text), Note.Text);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "LOGIC ERORR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateInfo.Visibility = Visibility.Collapsed;
        }
        private void IsEnabled_Update_Click(object sender, RoutedEventArgs e)
        {
            TextBox item = (TextBox)sender;
            if (item.Text == "")
            {
                Update.IsEnabled = false;
                return;
            }
            if (item.Name == "Grade")
            {
                int grade;
                try
                {
                    grade = int.Parse(item.Text);
                    if (!(grade >= 0 && grade <= 100))
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("the grade must be a number beween 0 to 100", "GRADE ERORR", MessageBoxButton.OK, MessageBoxImage.Error);
                    Update.IsEnabled = false;
                    return;
                }
            }
            Update.IsEnabled = true;
        }
    }
}
