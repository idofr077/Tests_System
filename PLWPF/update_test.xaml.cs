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
    /// Interaction logic for update_test.xaml
    /// </summary>
    public partial class update_test : UserControl
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
        public update_test()
        {
            InitializeComponent();
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try {
                IBL bl = BL.FactoryBl.getBl();
                if (!IsDigitsOnly(test_id.Text))
                    throw (new Exception("מספר מבחן חייב להיות מספרים בלבד"));
                if (!IsDigitsOnly(trainee_id.Text))
                    throw (new Exception("תעודת זהות של התלמיד חייבת להיות מספרים בלבד"));
                if (distance_good.IsChecked == false && distance_bad.IsChecked == false)
                {

                    throw (new Exception("חייב למלא ציון למרחק"));
                }
                if (reverse_good.IsChecked == false && reverse_bad.IsChecked == false)
                {
                    throw (new Exception("חייב למלא ציון לרברס"));
                }
                if (mirrors_good.IsChecked == false && mirrors_bad.IsChecked == false)
                {
                    throw (new Exception("חייב למלא ציון למראות"));
                }
                if (signals_good.IsChecked == false && signals_bad.IsChecked == false)
                {
                    throw (new Exception("חייב למלא ציון לאיתות"));
                }
                if (crosswalk_good.IsChecked == false && crosswalk_bad.IsChecked == false)
                {
                    throw (new Exception("חייב למלא ציון למעבר חצייה"));
                }
                if (grade_good.IsChecked == false && grade_bad.IsChecked == false)
                {
                    throw (new Exception("חייב למלא ציון לסופי"));
                }
                bl.update_test(int.Parse(test_id.Text), int.Parse(trainee_id.Text), distance_good.IsChecked, reverse_good.IsChecked, mirrors_good.IsChecked, signals_good.IsChecked, crosswalk_good.IsChecked, grade_good.IsChecked, mention.Text);
                MessageBox.Show("הפעולה בוצעה בהצלחה");
                test_id.Clear();
                trainee_id.Clear();
                distance_good.IsChecked=false;
                distance_bad.IsChecked = false;
                reverse_good.IsChecked = false;
                reverse_bad.IsChecked = false;
                mirrors_good.IsChecked = false;
                mirrors_bad.IsChecked = false;
                signals_good.IsChecked = false;
                signals_bad.IsChecked = false;
                crosswalk_good.IsChecked = false;
                crosswalk_bad.IsChecked = false;
                grade_good.IsChecked = false;
                grade_bad.IsChecked = false;
                mention.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
