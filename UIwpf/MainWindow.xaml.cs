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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddTester addTester;
        AddTrainee addTrainee;
        entrance ent = new entrance();
        
        public MainWindow()
        {
            InitializeComponent();
            ent.AddTesterB.Click += AddTesterB_Click;
            ent.AddTraineeB.Click += AddTraineeB_Click;
            Program.Children.Add(ent);
        }

        private void AddTraineeB_Click(object sender, RoutedEventArgs e)
        {
            if (addTrainee == null)
                addTrainee = new AddTrainee();
            Program.Children.Clear();
            Program.Children.Add(addTrainee);
        }

        private void AddTesterB_Click(object sender, RoutedEventArgs e)
        {
            if (addTester == null)
                addTester = new AddTester();
            Program.Children.Clear();
            Program.Children.Add(addTester);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Program.Children.Clear();
            Program.Children.Add(ent);
        }
    }
}
