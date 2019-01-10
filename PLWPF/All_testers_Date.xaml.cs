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
    /// Interaction logic for All_testers_Date.xaml
    /// </summary>
    public partial class All_testers_Date : UserControl
    {
        public All_testers_Date()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime _date = new DateTime();
            _date = (DateTime)(date.SelectedDate);
            DateTime date_and_hour = new DateTime(_date.Year, _date.Month, _date.Day, hour.SelectedIndex + 9, 0, 0);
            h.Children.Clear();
            d.Children.Clear();
            p.Children.Clear();
            List<Tester> items = (BL.FactoryBl.getBl().tester_time(date_and_hour));
            lvUsers.ItemsSource = items;
        }
    }
}
