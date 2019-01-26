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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : UserControl
    {
        List<Control> addChildren;
        public AddTester()
        {
            InitializeComponent();

            //add the Done_Click_IsEnabled func to all the field's events and initialize the list
            addChildren = new List<Control>();
            data.PersonAttribute.IdInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.LastNameInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.FirstNameInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.GenderInput.SelectionChanged += Done_Click_IsEnabled;
            data.PersonAttribute.BirthdateInput.SelectedDateChanged += Done_Click_IsEnabled;
            data.PersonAttribute.PhoneNumberInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.CityInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.StreetInput.TextChanged += Done_Click_IsEnabled;
            data.PersonAttribute.HouseNumberInput.TextChanged += Done_Click_IsEnabled;
            data.ExperienceInput.TextChanged += Done_Click_IsEnabled;
            data.MaxRangeInput.TextChanged += Done_Click_IsEnabled;
            data.MaxTestInput.TextChanged += Done_Click_IsEnabled;
            data.SpecialityInput.SelectionChanged += Done_Click_IsEnabled;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            string id = data.PersonAttribute.IdInput.Text;
            string lname = data.PersonAttribute.LastNameInput.Text;
            string fname = data.PersonAttribute.FirstNameInput.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), data.PersonAttribute.GenderInput.Text);
            DateTime Birthdate = data.PersonAttribute.BirthdateInput.SelectedDate.Value;
            string phone = data.PersonAttribute.PhoneNumberInput.Text;
            for(int i =0;i<lname.Length;i++)
            {
                if(lname[i] == ' ')
                {
                    lname = "last name";
                    data.PersonAttribute.LastNameInput.Text = lname;
                    MessageBox.Show("the last name must not contain  space", "Name error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            for (int i = 0; i < fname.Length; i++)
            {
                if (fname[i] == ' ')
                {
                    fname = "first name";
                    data.PersonAttribute.FirstNameInput.Text = fname;
                    MessageBox.Show("the first name must not contain  space", "Name error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                int.Parse(id);
            }
            catch (Exception)
            {

                MessageBox.Show("the ID must contain only digits", "ID error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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

            //create the tester
            try
            {
                Tester tester = new Tester(id, fname, lname, Birthdate, gender, phone, addrees, experience, max_tests, max_range, speciality, hours);
                Ibl help = FactoryBL.GetInstance();
                help.AddTester(tester);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Done_Click_IsEnabled(object sender, RoutedEventArgs e)
        {

            if (sender is TextBox)
            {
                if (((TextBox)sender).Text == "")
                {
                    addChildren.Remove((Control)sender);
                    Done.IsEnabled = false;
                    return;
                }
            }
            if (addChildren.Contains(sender))
                return;
            addChildren.Add((Control)sender);
            if (addChildren.Count == 13)
                Done.IsEnabled = true;
        }
    }
}
