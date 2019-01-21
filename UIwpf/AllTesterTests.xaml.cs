using System;
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
    /// Interaction logic for AllTesterTests.xaml
    /// </summary>
    public partial class AllTesterTests : UserControl
    {
        Tester tester;
        ObservableCollection<Test> obs;
        public AllTesterTests(Tester source)
        {
            tester = new Tester(source);
            InitializeComponent();

            Ibl help = FactoryBL.GetInstance();
            obs = new ObservableCollection<Test>(help.GetTests(t => t.Tester_id == tester.Id));
            AllTesterTest.DataContext = obs;



        }
    }
}
