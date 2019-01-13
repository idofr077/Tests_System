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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_Tester.xaml
    /// </summary>
    public partial class add_Tester : UserControl
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
        bool IsDigitAndDotssOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9')&&c!='.')
                    return false;
            }

            return true;
        }
        public add_Tester()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            IBL bl = BL.FactoryBl.getBl();
            try
            {
                
                gender _Gender = BE.gender.male;
                vehicle _expertise = BE.vehicle.private_vehicle;
                if (_gender.SelectedIndex == 0)
                {
                    _Gender = BE.gender.male;
                }
                else if (_gender.SelectedIndex == 1)
                {
                    _Gender = BE.gender.female;
                }
                else if (_gender.SelectedIndex == 2)
                {
                    _Gender = BE.gender.other;
                }
                if (expertise.SelectedIndex == 0)
                {
                    _expertise = BE.vehicle.private_vehicle;
                }
                else if (expertise.SelectedIndex == 1)
                {
                    _expertise = BE.vehicle.two_weels_vehicle;
                }
                else if (expertise.SelectedIndex == 2)
                {
                    _expertise = BE.vehicle.medium_track;
                }
                else if (expertise.SelectedIndex == 3)
                {
                    _expertise = BE.vehicle.heavy_track;
                }
                if (!IsDigitsOnly(_id.Text))
                {
                    throw (new Exception("תעודות זהות מורכבות מספרות בלבד"));

                }
                if (!IsDigitsOnly(_phone_number.Text))
                {
                    throw (new Exception("מספרי טלפון מורכבים מספרות בלבד"));

                }
                if (!IsDigitsOnly(max_way_to_go.Text))
                {
                    throw (new Exception("במרכיב מרחק מקסימלי נדרשים להכניס מספר שלם"));

                }
                if (!IsDigitAndDotssOnly(experience.Text))
                {
                    throw (new Exception("במרכיב נסיון נדרשים להכניס מספר"));

                }
                if (!IsDigitsOnly(num_of_test_in_week.Text))
                {
                    throw (new Exception("במרכיב מספר מבחנים שבועי מקסימלי נדרשים להכניס מספר שלם"));

                }
                if (!IsDigitsOnly(_house_number.Text))
                {
                    throw (new Exception("במרכיב מספר בית נדרשים להכניס מספר שלם"));

                }
                bool[,] work_time = new bool[5, 6];
                DateTime _date = new DateTime();
                _date = (DateTime)(_date_of_birth.SelectedDate);
                
                for (int i = 0; i < 6; i++)
                {
                    if (i==sunday.SelectedIndex)
                    {
                        work_time[0, i] = true;
                        sunday.SelectedItems.RemoveAt(0);
                       
                    }
                    else
                    {
                        work_time[0, i] = false;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (i == monday.SelectedIndex)
                    {
                        work_time[1, i] = true;
                        monday.SelectedItems.RemoveAt(0);
                    }
                    else
                    {
                        work_time[1, i] = false;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (i == tuesday.SelectedIndex)
                    {
                        work_time[2, i] = true;
                        tuesday.SelectedItems.RemoveAt(0);
                        
                       
                    }
                    else
                    {
                        work_time[2, i] = false;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (i == wednesday.SelectedIndex)
                    {
                        work_time[3, i] = true;
                        wednesday.SelectedItems.RemoveAt(0);
                    }
                    else
                    {
                        work_time[3, i] = false;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (i == thursday.SelectedIndex)
                    {
                        work_time[4, i] = true;
                        thursday.SelectedItems.RemoveAt(0);
                    }
                    else
                    {
                        work_time[4, i] = false;
                    }
                }
                bl.add_tester(int.Parse(_id.Text), (string)_last_name.Text, (string)_first_name.Text, _date, _Gender, long.Parse(_phone_number.Text), new BE.Address(_street.Text, int.Parse(_house_number.Text), _city.Text),float.Parse(experience.Text),int.Parse(num_of_test_in_week.Text), _expertise,work_time  ,int.Parse(max_way_to_go.Text));
                _id.Clear();
                _last_name.Clear();
                _first_name.Clear();
                _street.Clear();
                _house_number.Clear();
                _city.Clear();
                _phone_number.Clear();
                experience.Clear();
                max_way_to_go.Clear();
                num_of_test_in_week.Clear();
                MessageBox.Show("הפעולה בוצעה בהצלחה");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
