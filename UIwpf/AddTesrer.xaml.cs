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
namespace UIwpf
{
    /// <summary>
    /// Interaction logic for Tesrer.xaml
    /// </summary>
    public partial class AddTesrer : UserControl
    {
        public AddTesrer()
        {
            InitializeComponent();
            //add the frame
            DayOfWeek help1 = DayOfWeek.Sunday;
            for (int i = 2; i <= 6; i++, help1++)
            {
                TextBlock text = new TextBlock();
                text.Text = help1.ToString();
                Grid.SetRow(text, i);
                ScheduleTable.Children.Add(text);
            }
            int help2 = 9;
            for (int i = 1; i <= 6; i++, help2++)
            {
                TextBlock text = new TextBlock();
                text.Text = help2 + ":00";
                Grid.SetColumn(text, i);
                Grid.SetRow(text, 1);
                text.HorizontalAlignment = HorizontalAlignment.Center;
                ScheduleTable.Children.Add(text);
            }
            //add the check box to the ScheduleTable 
            for (int i = 2; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    CheckBox box = new CheckBox();
                    Grid.SetRow(box, i);
                    Grid.SetColumn(box, j);
                    box.HorizontalAlignment = HorizontalAlignment.Center;
                    ScheduleTable.Children.Add(box);
                }
            }

        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            string id = PersonAttribute.IdInput.Text;
            string lname = PersonAttribute.LastNameInput.Text;
            string fname = PersonAttribute.FirstNameInput.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), PersonAttribute.GenderInput.Text);
            DateTime Birthdate = PersonAttribute.BirthdateInput.SelectedDate.Value;
        }
    }
}
