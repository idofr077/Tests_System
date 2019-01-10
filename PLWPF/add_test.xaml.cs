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
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public add_Test()
        {
            InitializeComponent();
        }

  
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                IBL bl = FactoryBl.getBl();
                DateTime _date = new DateTime();
                _date = (DateTime)(date.SelectedDate);
                DateTime date_and_hour = new DateTime(_date.Year, _date.Month,_date.Day,hour.SelectedIndex+9,0,0);
               
                if (!IsDigitsOnly(id_tester.Text))
                {
                    throw (new Exception("תעודות זהות מורכבות מספרות בלבד"));
                    
                }
                if (!IsDigitsOnly(id_trainee.Text))
                {
                    throw (new Exception("תעודות זהות מורכבות מספרות בלבד"));

                }
                if (!IsDigitsOnly(house_number.Text))
                {
                    throw (new Exception("במרכיב מספר בית נדרשים להכניס מספר שלם"));

                }
                bl.add_test(int.Parse(id_tester.Text), int.Parse(id_trainee.Text), date_and_hour, new Address(street.Text, int.Parse(house_number.Text), city.Text));
                id_tester.Clear();
                id_trainee.Clear();
                street.Clear();
                house_number.Clear();
                city.Clear();
                MessageBox.Show("הפעולה בוצעה בהצלחה");
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
