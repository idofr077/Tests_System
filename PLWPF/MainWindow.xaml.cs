using System;
using System.Collections.Generic;
using System.IO;
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
        basic_page basic = new basic_page();
        contact_exp contact_Exp = new contact_exp();
        about_exp about_Exp = new about_exp();
        help_exp help_Exp = new help_exp();
      string[] audioPath = Directory.GetFiles(@"Music");
        Random rnd = new Random();
        int index;
        public static MainWindow FindParentWindow(DependencyObject child)
        {
            return MainWindow.GetWindow(child)as MainWindow;
        }
        public MainWindow()
        {
            InitializeComponent();
            dockPanel.Children.Add(d1);
            middle.Children.Add(basic);
               
            index = num();
            mediaElement.Source = new Uri(audioPath[index++],UriKind.Relative);
            mediaElement.Play();
            mediaElement.MediaEnded += sss;
        }
       int num()
        {

                   return rnd.Next(audioPath.Length);
        }

        private void sss(object sender, RoutedEventArgs e)
        {
            if (index < audioPath.Length)
            {
                mediaElement.Source = new Uri(audioPath[index++], UriKind.Relative);
                mediaElement.Play();
            }
            else
            {
                index = 0;
                mediaElement.Source = new Uri(audioPath[index++], UriKind.Relative);
                mediaElement.Play();
            }
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

        private void contact_exp(object sender, RoutedEventArgs e)
        {
            middle.Children.Clear();
            middle.Children.Add(contact_Exp);
        }

        private void about_click(object sender, RoutedEventArgs e)
        {
            middle.Children.Clear();
            middle.Children.Add(about_Exp);
        }

        private void help_click(object sender, RoutedEventArgs e)
        {
            middle.Children.Clear();
            middle.Children.Add(help_Exp);
        }

        private void main_click(object sender, RoutedEventArgs e)
        {
            middle.Children.Clear();
            middle.Children.Add(basic);
        }
    }
}
