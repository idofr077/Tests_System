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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IBL bl = BL.FactoryBl.getBl();
            try
            {
                //
                gender _Gender = BE.gender.male;
                vehicle _Vehicle = BE.vehicle.private_vehicle;
                kind_of_gearbox _Gearbox = BE.kind_of_gearbox.manual;
                if (gender.SelectedIndex == 0)
                {
                    _Gender = BE.gender.male;
                }
                else if (gender.SelectedIndex == 1)
                {
                    _Gender = BE.gender.female;
                }
                else if (gender.SelectedIndex == 2)
                {
                    _Gender = BE.gender.other;
                }
                if (vehicle.SelectedIndex == 0)
                {
                    _Vehicle = BE.vehicle.private_vehicle;
                }
                else if (vehicle.SelectedIndex == 1)
                {
                    _Vehicle = BE.vehicle.two_weels_vehicle;
                }
                else if (vehicle.SelectedIndex == 2)
                {
                    _Vehicle = BE.vehicle.medium_track;
                }
                else if (vehicle.SelectedIndex == 3)
                {
                    _Vehicle = BE.vehicle.heavy_track;
                }
                if (kind_of_gearbox.SelectedIndex == 0)
                {
                    _Gearbox = BE.kind_of_gearbox.manual;
                }
                if (kind_of_gearbox.SelectedIndex == 1)
                {
                    _Gearbox = BE.kind_of_gearbox.auto;
                }
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
                Trainee trainee=new Trainee();
                trainee = DataContext as Trainee;
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
