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
using System.Windows.Forms;
using BE;
using BL;


namespace UIwpf
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddTester addTester;
        AddTrainee addTrainee;
        TesterHome testerHome;
        TraineeHome traineeHome;
        DirectorHome DirectorHome;
        entrance ent = new entrance();
        
        public MainWindow()
        {
            StartProgram();
            InitializeComponent();
            ent.AddTesterB.Click += AddTesterB_Click;
            ent.AddTraineeB.Click += AddTraineeB_Click;
            ent.EnteredId.PreviewKeyDown += EnteredId_PreviewKeyDown;
            Program.Children.Add(ent);
        }

        private void EnteredId_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            if (e.Key != Key.Return)
                return;
            string id = ent.EnteredId.Text;
            if(id.Length <9 )
            {
                System.Windows.MessageBox.Show("id must have 9 numbers");
            }
            if(id == "000000000")
            {
                DirectorHome = new DirectorHome();
                ent.EnteredId.Clear();
                Program.Children.Clear();
                Program.Children.Add(DirectorHome);
            }
            else
            {

            Ibl help = FactoryBL.GetInstance();
            List<Tester> tester = help.GetTesters(t => t.Id == id);
            List<Trainee> trainee = help.GetTrainees(t => t.Id == id);
            if (trainee.Count==0 && tester.Count==0)
                System.Windows.MessageBox.Show("Not Exist!");
            else if (trainee.Count != 0 && tester.Count!=0)
                System.Windows.MessageBox.Show("ERORR");
            else if(tester.Count != 0)
            {
                testerHome = new TesterHome(tester[0]);
                testerHome.LogOutRequest += Logout_Request;
                ent.EnteredId.Clear();
                Program.Children.Clear();
                Program.Children.Add(testerHome);
            }
            else if(trainee.Count != 0)
            {
                traineeHome = new TraineeHome(trainee[0]);
                traineeHome.LogOutRequest += Logout_Request;
                ent.EnteredId.Clear();
                Program.Children.Clear();
                Program.Children.Add(traineeHome);
            }
            }
           
        }

       
        

        private void AddTraineeB_Click(object sender, RoutedEventArgs e)
        {
            if (addTrainee == null)
                addTrainee = new AddTrainee();
            addTrainee.LogOutRequest += Logout_Request;
            Program.Children.Clear();
            Program.Children.Add(addTrainee);
        }

        private void AddTesterB_Click(object sender, RoutedEventArgs e)
        {
            if (addTester == null)
                addTester = new AddTester();
            addTester.LogOutRequest += Logout_Request;
            Program.Children.Clear();
            Program.Children.Add(addTester);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            
           
            DialogResult result = System.Windows.Forms.MessageBox.Show("you sure you wnat logout ?", "hi",MessageBoxButtons.YesNo);
            if (result== System.Windows.Forms.DialogResult.Yes)
            {
                Program.Children.Clear();
                Program.Children.Add(ent);
            }
        }

        private void Logout_Request(object sender, EventArgs e)
        {
            Program.Children.Clear();
            Program.Children.Add(ent);
        }

        void StartProgram()
        {
            bool[][] work_time = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("at" + (DayOfWeek)i);
                for (int j = 0; j < 6; j++)
                {
                    work_time[i] = new bool[6];
                    Console.WriteLine((j + 9) + ":00 ?");
                    work_time[i][j] = true;
                }
            }
            DateTime date_of_birth = new DateTime(1960,10,10);
            Address address = new Address("Hayarkon", 34, "Beit_Shemesh");
            Tester item = new Tester("555555555", "noam", "bialik", date_of_birth, Gender.Female, "0586551940", address, 13, 20, 40.5, Vehicle.Private, work_time);
            Ibl help = FactoryBL.GetInstance();
            help.AddTester(item);


            address = new Address("grizim", 17, "kedumim");
            date_of_birth = new DateTime(200, 9, 2);
            Trainee trainee = new Trainee("111111111", "aviad", "davidi", date_of_birth, Gender.Female, "0525067871", address, Vehicle.Private, Gearbox.Automaton, "yyyy", "harv batat", 100);
            help.AddTrainee(trainee);
        }
    }
}
