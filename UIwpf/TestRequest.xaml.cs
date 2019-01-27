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
    /// Interaction logic for TestRequest.xaml
    /// </summary>
    public partial class TestRequest : UserControl
    {
        Trainee trainee;
        List<Control> addChildren;
        public TestRequest(Trainee source)
        {
            InitializeComponent();
            trainee = new Trainee(source);
            addChildren = new List<Control>();
            CityInput.TextChanged += AddTest_IsEnabled;
            StreetInput.TextChanged += AddTest_IsEnabled;
            HouseNumberInput.TextChanged += AddTest_IsEnabled;
            DayInput.SelectedDateChanged += AddTest_IsEnabled;
            HourInput.SelectionChanged += AddTest_IsEnabled;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int house_number;
            try
            {
                house_number = int.Parse(HouseNumberInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the house number must contain only digits", "house number error", MessageBoxButton.OK, MessageBoxImage.Error);
                HouseNumberInput.Text = "number";
                return;
            }
            Address addrees = new Address(StreetInput.Text, house_number,CityInput.Text);
            DateTime time = DayInput.SelectedDate.Value;
            int hour = int.Parse(HourInput.Text.Split(':')[0]);
            time = new DateTime(time.Year, time.Month, time.Day, hour, 0, 0);

            try
            {
                Test test = new Test(trainee.Id, addrees, time);
                FactoryBL.GetInstance().AddTest(test);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Visibility = Visibility.Collapsed;
        }
        private void AddTest_IsEnabled(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text == "")
                {
                    addChildren.Remove((Control)sender);
                    Add.IsEnabled = false;
                    return;
                }
            }
            if (!addChildren.Contains(sender))
                addChildren.Add((Control)sender);
            if (addChildren.Count == 5)
                Add.IsEnabled = true;
        }

    }
    
}
