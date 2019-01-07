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
    /// Interaction logic for basic_page.xaml
    /// </summary>
    public partial class basic_page : UserControl
    {
        public basic_page()
        {
            InitializeComponent();
        }

        private void mute_Click(object sender, RoutedEventArgs e)//בעצם זה היה שקט ועכשיו מגבירים
        {
            IBL bl = BL.FactoryBl.getBl();
            MainWindow father = MainWindow.FindParentWindow(this);
            father.mediaElement.Volume = 0;
            sound_or_not.Visibility = Visibility.Visible;
            mute_or_not.Visibility = Visibility.Hidden;
        }

        private void sound_Click(object sender, RoutedEventArgs e)//זה היה עובד ועכשיו משתיקים
        {
            IBL bl = BL.FactoryBl.getBl();
            MainWindow father = MainWindow.FindParentWindow(this);
            father.mediaElement.Volume = 0.5;
            sound_or_not.Visibility= Visibility.Hidden;
            mute_or_not.Visibility = Visibility.Visible;
        }
    }
}
