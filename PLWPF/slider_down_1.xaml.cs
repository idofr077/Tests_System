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
    /// Interaction logic for slider_down_1.xaml
    /// </summary>
    public partial class slider_down_1 : UserControl
    {

        public slider_down_1()
        {
            InitializeComponent();
        }

        private void add_trainee_Click(object sender, RoutedEventArgs e)
        {
           
                IBL bl = BL.FactoryBl.getBl();
                MainWindow father = MainWindow.FindParentWindow(this);
                father.middle.Children.Clear();
                add_Trainee temp = new add_Trainee();
                father.middle.Children.Add(temp);

              
                    
      
        }
    }
}
