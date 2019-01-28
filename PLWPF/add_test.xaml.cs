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
using System.Threading;
using BL;
using BE;
using System.ComponentModel;

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
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
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

                worker.RunWorkerAsync();              

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            id_tester.Clear();
            id_trainee.Clear();
            street.Clear();
            house_number.Clear();
            city.Clear();
            if(Configuration.id_test-1>0)
            MessageBox.Show("הפעולה בוצעה בהצלחה \n מספר המבחן הוא:" + (Configuration.id_test - 1));
          
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
                Dispatcher.Invoke(action);
            
          
        }
        private void action()
        {
            try
            {
                DateTime _date = DateTime.Parse(date.Text);
                DateTime date_and_hour = new DateTime(_date.Year, _date.Month, _date.Day, hour.SelectedIndex + 9, 0, 0);
                BL.FactoryBl.getBl().add_test(int.Parse(id_tester.Text), int.Parse(id_trainee.Text), date_and_hour, new Address(street.Text, int.Parse(house_number.Text), city.Text));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
