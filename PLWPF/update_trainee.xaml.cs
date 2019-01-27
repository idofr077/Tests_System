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
    /// Interaction logic for update_trainee.xaml
    /// </summary>
    public partial class update_trainee : UserControl

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
        public update_trainee()
        {
            InitializeComponent();
            List<int> idis = new List<int>();
            for (int i = 0; i < BL.FactoryBl.getBl().all_trainee().Count; i++)
            {
                idis.Add(BL.FactoryBl.getBl().all_trainee()[i].id);
            }
            id.ItemsSource = idis;
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
                Trainee trainee = new Trainee();
                trainee = DataContext as Trainee;
                bl.update_trainee(trainee);
                
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

        private void id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IBL bl = BL.FactoryBl.getBl();
            Trainee temp = bl.all_trainee().Find(match);
            first_name.Text = temp.first_name;
            last_name.Text = temp.last_name;
            phone_number.Text = temp.phone.ToString();
            school.Text = temp.school;
            teacher.Text = temp.teacher_name;
            num_of_lessons.Text = temp.num_of_lessons.ToString();
            date_of_birth.SelectedDate = temp.date_of_birth;
            if (temp.Gender == BE.gender.male)
                gender.SelectedIndex = 0;
            else if (temp.Gender == BE.gender.female)
                gender.SelectedIndex = 1;
            else gender.SelectedIndex = 2;
            if (temp.learn_vehicle == BE.vehicle.private_vehicle)
                vehicle.SelectedIndex = 0;
            else if (temp.learn_vehicle == BE.vehicle.two_weels_vehicle)
                vehicle.SelectedIndex = 1;
            else if (temp.learn_vehicle == BE.vehicle.medium_track)
                vehicle.SelectedIndex = 2;
            else vehicle.SelectedIndex = 3;
            if (temp.gearbox == BE.kind_of_gearbox.auto)
                kind_of_gearbox.SelectedIndex = 0;
            else kind_of_gearbox.SelectedIndex = 1;
            city.Text = temp.address.city;
            street.Text = temp.address.street;
            house_number.Text = temp.address.num.ToString();
        }
        private bool match(Trainee _trainee)
        {
            if (_trainee.id == int.Parse(id.SelectedItem.ToString()))
            {
                return true;
            }
            return false;
        }

    }
}
