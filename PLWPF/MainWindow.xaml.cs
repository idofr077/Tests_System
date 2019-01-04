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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        slider_down_1 d1 = new slider_down_1();
        slider_down_2 d2 = new slider_down_2();
        slider_down_3 d3 = new slider_down_3();
        public MainWindow()
        {
            InitializeComponent();
            dockPanel.Children.Add(d1);
            
        }

        private void left_move_slider_Click(object sender, RoutedEventArgs e)
        {
            if (dockPanel.Children.IndexOf(d1) >= 0)
            {
                dockPanel.Children.Remove(d1);
                dockPanel.Children.Add(d2);
            }
            else if (dockPanel.Children.IndexOf(d2) >= 0)
            {
                dockPanel.Children.Remove(d2);
                dockPanel.Children.Add(d3);
            }
            else if (dockPanel.Children.IndexOf(d3) >= 0)
            {
                dockPanel.Children.Remove(d3);
                dockPanel.Children.Add(d1);
            }
        }
        private void right_move_slider_Click(object sender,RoutedEventArgs e)
        {
            if (dockPanel.Children.IndexOf(d1) >= 0)
            {
                dockPanel.Children.Remove(d1);
                dockPanel.Children.Add(d3);
            }
            else if (dockPanel.Children.IndexOf(d2) >= 0)
            {
                dockPanel.Children.Remove(d2);
                dockPanel.Children.Add(d1);
            }
            else if (dockPanel.Children.IndexOf(d3) >= 0)
            {
                dockPanel.Children.Remove(d3);
                dockPanel.Children.Add(d2);
            }
        }
        
 
    }
}
