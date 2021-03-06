﻿using System;
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

namespace UIwpf
{
    /// <summary>
    /// Interaction logic for DirectorUserControl.xaml
    /// </summary>
    public partial class DirectorHome : UserControl
    {
        AllTesters Testers;
        AllTests Tests;
        AllTrainees Trainees;
        public DirectorHome()
        {
            InitializeComponent();
        }

        private void Testers_Click(object sender, RoutedEventArgs e)
        {
            if (Testers == null)
                Testers = new AllTesters();
            data.Children.Clear();
            data.Children.Add(Testers);
        }

        private void Trainees_Click(object sender, RoutedEventArgs e)
        {
            if (Trainees == null)
                Trainees = new AllTrainees();
            data.Children.Clear();
            data.Children.Add(Trainees);
        }

        private void Tests_Click(object sender, RoutedEventArgs e)
        {
            if (Tests == null)
                Tests = new AllTests();
            data.Children.Clear();
            data.Children.Add(Tests);
        }
    }
}
