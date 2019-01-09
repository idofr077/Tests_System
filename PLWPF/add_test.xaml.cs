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
using BL;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_Test.xaml
    /// </summary>
    public partial class add_Test : UserControl
    {
        public add_Test()
        {
            InitializeComponent();
        }

  
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                IBL bl = FactoryBl.getBl();
                DateTime date_and_hour = new DateTime();
                date_and_hour = (DateTime)(date.SelectedDate);
                date_and_hour.AddHours(hour.SelectedIndex + 9);
           
                bl.add_test(int.Parse(id_tester.Text), int.Parse(id_trainee.Text), date_and_hour, new Address(street.Text, int.Parse(house_number.Text), city.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
