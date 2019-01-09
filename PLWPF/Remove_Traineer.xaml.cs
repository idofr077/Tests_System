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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Remove_Traineer.xaml
    /// </summary>
    public partial class Remove_Traineer : UserControl
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
        public Remove_Traineer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IBL bl = FactoryBl.getBl();
                if (!IsDigitsOnly(id_remove.Text))
                {
                    throw (new Exception("תעודות זהות מורכבות מספרות בלבד"));

                }
                bl.remove_trainee(int.Parse(id_remove.Text));
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }
    }
}
