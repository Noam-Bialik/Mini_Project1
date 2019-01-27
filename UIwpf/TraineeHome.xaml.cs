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
    /// Interaction logic for TraineeHome.xaml
    /// </summary>
    public partial class TraineeHome : UserControl
    {
        Trainee trainee;
        UpdateTrainee updateTrainee;
        RemoveTrainee removeTrainee;
        AllTestersInRadius inRadius;
        AllTraineeTests traineeTests;
        TestRequest TestRequest;
        public TraineeHome(Trainee t)
        {
            InitializeComponent();
            trainee = new Trainee(t);
        }

        public event EventHandler LogOutRequest;

        private void deleted(object sender, EventArgs e)
        {
            object j = new object();
            LogOutRequest(j, new EventArgs());
        }

        private void UpdateTrainee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {

            }
            updateTrainee = new UpdateTrainee(trainee);
            data.Children.Add(updateTrainee);
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
            removeTrainee = new RemoveTrainee(trainee.Id);
            removeTrainee.the_trainee_deleted += deleted;
            data.Children.Add(removeTrainee);
        }

        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {
            }
            TestRequest = new TestRequest(trainee);
            data.Children.Add(TestRequest);
        }

        private void AllTestersInRadius_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.Children.Clear();
            }
            catch (Exception)
            {
            }
            inRadius = new AllTestersInRadius(trainee);
            data.Children.Add(inRadius);
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
            traineeTests = new AllTraineeTests(trainee);
            data.Children.Add(traineeTests);
        }

    }
}
