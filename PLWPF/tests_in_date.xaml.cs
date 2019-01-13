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
    /// Interaction logic for tests_in_date.xaml
    /// </summary>
    public partial class tests_in_date : UserControl
    {
        public tests_in_date()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime _date = new DateTime();
            _date = (DateTime)(date.SelectedDate);
            search.Visibility = Visibility.Hidden;
            List<Test> items = BL.FactoryBl.getBl().test_on_date(_date);
            lvUsers.ItemsSource = items;
        }
    }
}
