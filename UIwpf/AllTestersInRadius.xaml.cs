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
    /// Interaction logic for AllTestersInRadius.xaml
    /// </summary>
    public partial class AllTestersInRadius : UserControl
    {
        Address address;
        public AllTestersInRadius(Trainee source)
        {
            InitializeComponent();
            address = new Address(source._Address.Street, source._Address.Building_number, source._Address.City);
            CityInput.Text = address.City;
            StreetInput.Text = address.Street;
            HouseNumberInput.Text = address.Building_number.ToString();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            address.City = CityInput.Text;
            address.Street = StreetInput.Text;
            try
            {
                address.Building_number = int.Parse(HouseNumberInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("the house number must contain only digits", "house number error", MessageBoxButton.OK, MessageBoxImage.Error);
                HouseNumberInput.Text = "number";
                return;
            }
            try
            {
                int help = (int)distance.Value;
                TestersNumber.Text = FactoryBL.GetInstance().InRadius(address, help).Count.ToString();
            }
            catch (Exception)
            {
                TestersNumber.Text = 0.ToString();
            }
        }
    }
}
