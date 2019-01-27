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
    /// Interaction logic for add_Trainee.xaml
    /// </summary>
    public partial class add_Trainee : UserControl
    {
        Trainee trainee;
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public add_Trainee()
        {
            InitializeComponent();
            trainee = new Trainee();
            DataContext = trainee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IBL bl = BL.FactoryBl.getBl();
            try
            {
                //
          
                if (!IsDigitsOnly(id.Text))
                {
                    throw (new Exception("תעודות זהות מורכבות מספרות בלבד"));

                }
                if (!IsDigitsOnly(phone_number.Text))
                {
                    throw (new Exception("מספרי טלפון מורכבים מספרות בלבד"));

                }
                if (!IsDigitsOnly(num_of_lessons.Text))
                {
                    throw (new Exception("במרכיב מספר שיעורים נדרשים להכניס מספר שלם"));

                }
                if (!IsDigitsOnly(house_number.Text))
                {
                    throw (new Exception("במרכיב מספר בית נדרשים להכניס מספר שלם"));

                }
                DateTime _date = new DateTime();
                _date = (DateTime)(date_of_birth.SelectedDate);
                trainee.address = new Address(street.Text.ToString(), int.Parse(house_number.Text), city.Text);
                bl.add_trainee(trainee);
                id.Clear();
                last_name.Clear();
                first_name.Clear();
                street.Clear();
                house_number.Clear();
                city.Clear();
                phone_number.Clear();
                school.Clear();
                teacher.Clear();
                num_of_lessons.Clear();
                MessageBox.Show("הפעולה בוצעה בהצלחה");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

   
    }
}
