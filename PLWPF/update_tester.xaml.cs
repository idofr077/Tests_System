﻿using System;
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
    /// Interaction logic for update_tester.xaml
    /// </summary>
    public partial class update_tester : UserControl
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
                if ((c < '0' || c > '9') && c != '.')
                    return false;
            }

            return true;
        }
        public update_tester()
        {
            InitializeComponent();
            List<int> idis = new List<int>();
            for (int i = 0; i < BL.FactoryBl.getBl().all_tester().Count; i++)
            {
                idis.Add(BL.FactoryBl.getBl().all_tester()[i].id);
            }
            id.ItemsSource = idis;

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
                if (!IsDigitsOnly(id.Text))
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
                    if (i == sunday.SelectedIndex)
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
                Tester tester = new Tester(int.Parse(id.Text), (string)_last_name.Text, (string)_first_name.Text, _date, _Gender, long.Parse(_phone_number.Text), new BE.Address(_street.Text, int.Parse(_house_number.Text), _city.Text), float.Parse(experience.Text), int.Parse(num_of_test_in_week.Text), _expertise, work_time, int.Parse(max_way_to_go.Text));
                bl.update_tester(tester);
                _last_name.Clear();
                _first_name.Clear();
                _street.Clear();
                _house_number.Clear();
                _city.Clear();
                _phone_number.Clear();
                experience.Clear();
                max_way_to_go.Clear();
                num_of_test_in_week.Clear();
                id.SelectedIndex=-1;
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
            Tester temp=bl.all_tester().Find(match);
            _first_name.Text = temp.first_name;
            _last_name.Text = temp.last_name;
            _phone_number.Text =temp.phone.ToString();
            num_of_test_in_week.Text = temp.max_testPerWeek.ToString();
            _date_of_birth.SelectedDate = temp.date_of_birth;
            if (temp.Gender == gender.male)
                _gender.SelectedIndex = 0;
            else if (temp.Gender == gender.female)
                _gender.SelectedIndex = 1;
            else _gender.SelectedIndex = 2;
            if (temp.tester_expertice == vehicle.private_vehicle)
                expertise.SelectedIndex = 0;
            else if (temp.tester_expertice == vehicle.two_weels_vehicle)
                expertise.SelectedIndex = 1;
            else if (temp.tester_expertice == vehicle.medium_track)
                expertise.SelectedIndex = 2;
            else expertise.SelectedIndex = 3;
            max_way_to_go.Text = temp.max_way.ToString();
            _city.Text = temp.address.city;
            _street.Text = temp.address.street;
            _house_number.Text = temp.address.num.ToString();
            experience.Text = temp.expirence.ToString();
            for (int i = 0; i < 6; i++)
            {
                if (temp.work_time[0, i])
                    sunday.SelectedItems.Add(sunday.Items[i]);

            }
            for (int i = 0; i < 5; i++)
            {
                if (temp.work_time[1, i])
                    monday.SelectedItems.Add(monday.Items[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (temp.work_time[2, i])
                    tuesday.SelectedItems.Add(tuesday.Items[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (temp.work_time[3, i])
                    wednesday.SelectedItems.Add(wednesday.Items[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (temp.work_time[4, i])
                    thursday.SelectedItems.Add(thursday.Items[i]) ;
            }
        }
        private bool match (Tester _tester)
        {
            if (_tester.id==int.Parse(id.SelectedItem.ToString()))
            {
                return true;
            }
            return false;
        }

    }
}
