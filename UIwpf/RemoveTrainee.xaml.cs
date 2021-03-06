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
using BL;
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for RemoveTraainee.xaml
    /// </summary>
    public partial class RemoveTrainee : UserControl
    {
        string id;
        public RemoveTrainee(string trainee_id)
        {
            InitializeComponent();
            id = trainee_id;
        }
        public event EventHandler the_trainee_deleted;
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Ibl help = FactoryBL.GetInstance();
            try
            {
                help.RemoveTrainee(id);
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "logic error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Visibility = Visibility.Collapsed;
            the_trainee_deleted(this, new EventArgs());
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
