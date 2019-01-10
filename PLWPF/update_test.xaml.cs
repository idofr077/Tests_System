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
            IBL bl = BL.FactoryBl.getBl();
            bl.update_test(int.Parse(test_id.Text), int.Parse(trainee_id.Text), distance_ans.IsChecked, reverse_ans.IsChecked, mirrors_ans.IsChecked, signals_ans.IsChecked, crosswalk_ans.IsChecked, grade_ans.IsChecked, mention.Text);
        }
    }
}
