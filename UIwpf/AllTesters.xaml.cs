﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AllTesters.xaml
    /// </summary>
    public partial class AllTesters : UserControl
    {
        public AllTesters()
        {
            InitializeComponent();
            Ibl help = FactoryBL.GetInstance();
            DataContext = new ObservableCollection<Tester>(help.GetTesters());
        }

        
    }
}
