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
using BE;
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for TesterHome.xaml
    /// </summary>
    public partial class TesterHome : UserControl
    {
        Tester tester;

        public TesterHome(Tester tester)
        {
            InitializeComponent();
            this.tester = new Tester(tester);
        }

        private void UpdateTester_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UpdateTest_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AllTests_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}