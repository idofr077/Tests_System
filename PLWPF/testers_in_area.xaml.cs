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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for testers_in_area.xaml
    /// </summary>
    public partial class testers_in_area : UserControl
    {
        public testers_in_area()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
         
            
            Address temp = new Address(street.Text,int.Parse(number.Text),city.Text);
            search.Children.Clear();
            p.Children.Clear();
            j.Children.Clear();
            List<Tester> items = (BL.FactoryBl.getBl().testers_area(temp));
            lvUsers.ItemsSource = items;
        }
    }
}
