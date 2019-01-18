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
    /// Interaction logic for Tesrer.xaml
    /// </summary>
    public partial class AddTesrer : UserControl
    {
        public AddTesrer()
        {
            InitializeComponent();
            //add the frame
            DayOfWeek help1 = DayOfWeek.Sunday;
            for (int i = 2; i <= 6; i++, help1++)
            {
                TextBlock text = new TextBlock();
                text.Text = help1.ToString();
                Grid.SetRow(text, i);
                ScheduleTable.Children.Add(text);
            }
            int help2 = 9;
            for (int i = 1; i <= 6; i++, help2++)
            {
                TextBlock text = new TextBlock();
                text.Text = help2 + ":00";
                Grid.SetColumn(text, i);
                Grid.SetRow(text, 1);
                text.HorizontalAlignment = HorizontalAlignment.Center;
                ScheduleTable.Children.Add(text);
            }
            //add the check box to the ScheduleTable 
            for (int i = 2; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    CheckBox box = new CheckBox();
                    Grid.SetRow(box, i);
                    Grid.SetColumn(box, j);
                    box.HorizontalAlignment = HorizontalAlignment.Center;
                    ScheduleTable.Children.Add(box);
                }
            }

        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            string id = PersonAttribute.IdInput.Text;
            string lname = PersonAttribute.LastNameInput.Text;
            string fname = PersonAttribute.FirstNameInput.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), PersonAttribute.GenderInput.Text);
            DateTime Birthdate = PersonAttribute.BirthdateInput.SelectedDate.Value;
            string phone = PersonAttribute.PhoneNumberInput.Text;
            int house_number;
            try
            {
                house_number = int.Parse(PersonAttribute.HouseNumberInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the house number must contain only digits", "house number error", MessageBoxButton.OK, MessageBoxImage.Error);
                PersonAttribute.HouseNumberInput.Text = "number";
                return;
            }
            Address addrees = new Address(PersonAttribute.StreetInput.Text, house_number, PersonAttribute.CityInput.Text);
            int experience;
            try
            {
                experience = int.Parse(ExperienceInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Experience must contain only digits", "Experience error", MessageBoxButton.OK, MessageBoxImage.Error);
                ExperienceInput.Text = "0";
                return;
            }
            int max_tests;
            try
            {
                max_tests = int.Parse(MaxTestInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Max Tests Per Week must contain only digits", "Max Tests Per Week error", MessageBoxButton.OK, MessageBoxImage.Error);
                MaxTestInput.Text = "0";
                return;
            }
            int max_range;
            try
            {
                max_range = int.Parse(MaxRangeInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the Max Range must contain only digits", "Max Range( error", MessageBoxButton.OK, MessageBoxImage.Error);
                MaxRangeInput.Text = "0";
                return;
            }
            Vehicle speciality = (Vehicle)Enum.Parse(typeof(Vehicle), SpecialityInput.Text);
            bool[][] hours = new bool[5][];
            for (int i = 0; i < 5; i++)
                hours[i] = new bool[6];
            //Initialize hours array
            foreach (var item in ScheduleTable.Children)
            {
                if (item is CheckBox)
                {
                    CheckBox help = (CheckBox)item;
                    if(help.IsChecked == true)
                    {
                        hours[Grid.GetRow(help) - 2][Grid.GetColumn(help) - 1] = true;
                    }
                }
            }

            //create the tester
            try
            {
                Tester tester = new Tester(id, fname, lname, Birthdate, gender, phone, addrees, experience, max_tests, max_range, speciality, hours);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //צריך לעשות שיהיה אפשר ללחוץ על הכפתור רק אחרי שכל השדות מולאו כי אחרת זה יכול ליצור שגיאות זמן ריצה(עדיף לעשות את זה מאשר לטפל בשגיאות זמן ריצה )חשבתי על לעשות את זה עם האיוונטים
    }
}
