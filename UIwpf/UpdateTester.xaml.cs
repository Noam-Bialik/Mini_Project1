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
    /// Interaction logic for UpdateTester.xaml
    /// </summary>
    public partial class UpdateTester : Page
    {
        List<TextBox> empty;
        public UpdateTester(Tester source)
        {
            InitializeComponent();

            //add the Create_Click_IsEnabled func to all the field's events and initialize the list
            empty = new List<TextBox>();
            data.PersonAttribute.IdInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.LastNameInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.FirstNameInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.GenderInput.SelectionChanged += Create_Click_IsEnabled;
            data.PersonAttribute.BirthdateInput.SelectedDateChanged += Create_Click_IsEnabled;
            data.PersonAttribute.PhoneNumberInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.CityInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.StreetInput.TextChanged += Create_Click_IsEnabled;
            data.PersonAttribute.HouseNumberInput.TextChanged += Create_Click_IsEnabled;
            data.ExperienceInput.TextChanged += Create_Click_IsEnabled;
            data.MaxRangeInput.TextChanged += Create_Click_IsEnabled;
            data.MaxTestInput.TextChanged += Create_Click_IsEnabled;
            data.SpecialityInput.SelectionChanged += Create_Click_IsEnabled;


            //copy the values from the source
            data.PersonAttribute.IdInput.Text = source.Id;
            data.PersonAttribute.IdInput.IsEnabled = false;
            data.PersonAttribute.LastNameInput.Text = source.Last_name;
            data.PersonAttribute.FirstNameInput.Text = source.First_name;
            //data.PersonAttribute.GenderInput;
            data.PersonAttribute.BirthdateInput.SelectedDate = source.Birthdate;
            data.PersonAttribute.PhoneNumberInput.Text = source.Phone_number;
            data.PersonAttribute.CityInput.Text = source._Address.City;
            data.PersonAttribute.StreetInput.Text = source._Address.Street;
            data.PersonAttribute.HouseNumberInput.Text = source._Address.Building_number.ToString();
            data.ExperienceInput.Text = source.Experience.ToString();
            data.MaxRangeInput.Text = source.Max_range.ToString();
            data.MaxTestInput.Text = source.Max_tests_per_week.ToString();
            //data.SpecialityInput;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string id = data.PersonAttribute.IdInput.Text;
            string lname = data.PersonAttribute.LastNameInput.Text;
            string fname = data.PersonAttribute.FirstNameInput.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), data.PersonAttribute.GenderInput.Text);
            DateTime Birthdate = data.PersonAttribute.BirthdateInput.SelectedDate.Value;
            string phone = data.PersonAttribute.PhoneNumberInput.Text;
            int house_number;
            try
            {
                house_number = int.Parse(data.PersonAttribute.HouseNumberInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the house number must contain only digits", "house number error", MessageBoxButton.OK, MessageBoxImage.Error);
                data.PersonAttribute.HouseNumberInput.Text = "number";
                return;
            }
            Address addrees = new Address(data.PersonAttribute.StreetInput.Text, house_number, data.PersonAttribute.CityInput.Text);
            int experience;
            try
            {
                experience = int.Parse(data.ExperienceInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Experience must contain only digits", "Experience error", MessageBoxButton.OK, MessageBoxImage.Error);
                data.ExperienceInput.Text = "0";
                return;
            }
            int max_tests;
            try
            {
                max_tests = int.Parse(data.MaxTestInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Max Tests Per Week must contain only digits", "Max Tests Per Week error", MessageBoxButton.OK, MessageBoxImage.Error);
                data.MaxTestInput.Text = "0";
                return;
            }
            int max_range;
            try
            {
                max_range = int.Parse(data.MaxRangeInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Max Range must contain only digits", "Max Range( error", MessageBoxButton.OK, MessageBoxImage.Error);
                data.MaxRangeInput.Text = "0";
                return;
            }
            Vehicle speciality = (Vehicle)Enum.Parse(typeof(Vehicle), data.SpecialityInput.Text);
            bool[][] hours = new bool[5][];
            for (int i = 0; i < 5; i++)
                hours[i] = new bool[6];
            //Initialize hours array
            foreach (var item in data.ScheduleTable.Children)
            {
                if (item is CheckBox)
                {
                    CheckBox help = (CheckBox)item;
                    if (help.IsChecked == true)
                    {
                        hours[Grid.GetRow(help) - 2][Grid.GetColumn(help) - 1] = true;
                    }
                }
            }

            //update the tester
            try
            {
                Tester tester = new Tester(id, fname, lname, Birthdate, gender, phone, addrees, experience, max_tests, max_range, speciality, hours);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Create_Click_IsEnabled(object sender, RoutedEventArgs e)
        {

            if (sender is TextBox)
            {
                if (((TextBox)sender).Text == "")
                {
                    Create.IsEnabled = false;
                    empty.Add((TextBox)sender));
                    return;
                }
                else
                {
                    empty.Remove((TextBox)sender));
                }

                if (empty.Count == 0)
                    Create.IsEnabled = true;
            }

        }
    }
}
