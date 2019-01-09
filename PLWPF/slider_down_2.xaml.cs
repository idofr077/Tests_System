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
    /// Interaction logic for slider_down_2.xaml
    /// </summary>
    public partial class slider_down_2 : UserControl
    {
        public slider_down_2()
        {
            InitializeComponent();
        }

        private void all_testers_click(object sender, RoutedEventArgs e)
        {
            
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new all_testers());
        }

        private void update_trainee_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new update_trainee());
        }

        private void all_test_click(object sender, RoutedEventArgs e)
        {
           
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new all_tests());
        }
    }
}
