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
    /// Interaction logic for UpdateTrainee.xaml
    /// </summary>
    public partial class UpdateTrainee : UserControl
    {
        public UpdateTrainee(Trainee t)
        {
            InitializeComponent();
            // set the existing values.
            // for person
            
            try {
                TraineeUC.person.IdInput.Text = t.Id;
                TraineeUC.person.LastNameInput.Text = t.Id;
                TraineeUC.person.FirstNameInput.Text = t.First_name;
                TraineeUC.person.BirthdateInput.SelectedDate = t.Birthdate;
                TraineeUC.person.GenderInput.Text = t._Gender.ToString();
                TraineeUC.person.PhoneNumberInput.Text = t.Phone_number;
                TraineeUC.person.CityInput.Text = t._Address.City;
                TraineeUC.person.StreetInput.Text = t._Address.Street;
                TraineeUC.person.HouseNumberInput.Text = t._Address.Building_number.ToString();
                //for the others
                TraineeUC.SpecialityInput.Text = t._Speciality.ToString();
                TraineeUC.GearboxInput.Text = t._Gearbox.ToString();
                TraineeUC.SchoolNameInput.Text = t.School_name;
                TraineeUC.TeacherNameInput.Text = t.School_name;
                TraineeUC.LessonsCounterInput.Text = t.Lessons_count.ToString();              
            }
            catch
            {
                MessageBox.Show("try again. can't open!");
                return;
            }
           
            }

        private void DoneUpdate_Click(object sender, RoutedEventArgs e)
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
            int numlessons = int.Parse(TraineeUC.LessonsCounterInput.Text);

            Trainee trainee = new Trainee(id, fname, lname, Birthdate, gender, phone, addrees, speciality, gearbox, sname, tname, numlessons);
            Ibl help = FactoryBL.GetInstance();
            help.UpdateTrainee(trainee);

        }
    }
}
