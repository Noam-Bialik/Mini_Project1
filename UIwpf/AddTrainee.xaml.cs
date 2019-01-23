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
        public AddTrainee()
        {
            InitializeComponent();
        }

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
                int numlessons = int.Parse(TraineeUC.LessonsCounterInput.Text);

                Trainee trainee = new Trainee(id, fname, lname, Birthdate, gender, phone, addrees, speciality,gearbox, sname,tname, numlessons);
                Ibl help = FactoryBL.GetInstance();
                help.AddTrainee(trainee);

            }
            catch
            {
                MessageBox.Show("LA    LA");
            }
        }
    }
}
