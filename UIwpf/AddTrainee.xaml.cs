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
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : UserControl
    {
        List<Control> addChildren;
        public AddTrainee()
        {
            InitializeComponent();
            //add the Done_IsEnabled func to all the field's events and initialize the list
            addChildren = new List<Control>();
            TraineeUC.person.IdInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.LastNameInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.FirstNameInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.GenderInput.SelectionChanged += Done_IsEnabled;
            TraineeUC.person.BirthdateInput.SelectedDateChanged += Done_IsEnabled;
            TraineeUC.person.PhoneNumberInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.CityInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.StreetInput.TextChanged += Done_IsEnabled;
            TraineeUC.person.HouseNumberInput.TextChanged += Done_IsEnabled;
            TraineeUC.SpecialityInput.SelectionChanged += Done_IsEnabled;
            TraineeUC.GearboxInput.SelectionChanged += Done_IsEnabled;
            TraineeUC.SchoolNameInput.TextChanged += Done_IsEnabled;
            TraineeUC.TeacherNameInput.TextChanged += Done_IsEnabled;
            TraineeUC.LessonsCounterInput.TextChanged += Done_IsEnabled;
        }

        public event EventHandler LogOutRequest;

        private void DoneTrainee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = TraineeUC.person.IdInput.Text;
                string fname = TraineeUC.person.FirstNameInput.Text;
                string lname = TraineeUC.person.LastNameInput.Text;
                Gender gender = (Gender)Enum.Parse(typeof(Gender), TraineeUC.person.GenderInput.Text);
                DateTime Birthdate = TraineeUC.person.BirthdateInput.SelectedDate.Value;
                string phone = TraineeUC.person.PhoneNumberInput.Text;
                int house_number;
                try
                {
                    house_number = int.Parse(TraineeUC.person.HouseNumberInput.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("the house number must contain only digits", "house number error", MessageBoxButton.OK, MessageBoxImage.Error);
                    TraineeUC.person.HouseNumberInput.Text = "number";
                    return;
                }
                Address addrees = new Address(TraineeUC.person.StreetInput.Text, house_number, TraineeUC.person.CityInput.Text);
                Vehicle speciality = (Vehicle)Enum.Parse(typeof(Vehicle), TraineeUC.SpecialityInput.Text);
                Gearbox gearbox = (Gearbox)Enum.Parse(typeof(Gearbox), TraineeUC.GearboxInput.Text);
                string sname = TraineeUC.SchoolNameInput.Text;
                string tname = TraineeUC.TeacherNameInput.Text;
                int numlessons;
                try
                {
                    numlessons = int.Parse(TraineeUC.LessonsCounterInput.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("the number lessons must contain only digits", "numer lessons error", MessageBoxButton.OK, MessageBoxImage.Error);
                    TraineeUC.person.HouseNumberInput.Text = "number";
                    return;
                }
                try
                {

                Trainee trainee = new Trainee(id, fname, lname, Birthdate, gender, phone, addrees, speciality, gearbox, sname, tname, numlessons);
                Ibl help = FactoryBL.GetInstance();
                help.AddTrainee(trainee);

                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK);
                }

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK);
            }
            MessageBox.Show("Trainee successfully added", "Tracking message", MessageBoxButton.OK, MessageBoxImage.Information);

            LogOutRequest(this, new EventArgs());
        }

        private void Done_IsEnabled(object sender, RoutedEventArgs e)
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
            if (!addChildren.Contains(sender))
                addChildren.Add((Control)sender);

            if (addChildren.Count == 14)
                Done.IsEnabled = true;
        }
    }
}
