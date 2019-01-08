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
    /// Interaction logic for add_tester.xaml
    /// </summary>
    public partial class add_tester : UserControl
    {
        public add_tester()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            IBL bl = BL.FactoryBl.getBl();
            try
            {
                //
                gender _Gender = BE.gender.male;
                vehicle _expertise = BE.vehicle.private_vehicle;
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
                


                DateTime _date = new DateTime();
                _date = (DateTime)(date_of_birth.SelectedDate);

                bl.add_trainee(int.Parse(id.Text), (string)last_name.Text, (string)first_name.Text, _date, _Gender, long.Parse(phone_number.Text), new BE.Address(street.Text, int.Parse(house_number.Text), city.Text), _Vehicle, _Gearbox, school.Text, teacher.Text, int.Parse(num_of_lessons.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            */
        }
    }
}
