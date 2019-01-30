using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            //p.Children.Clear();
            //j.Children.Clear();
            Address temp = new Address(street.Text, int.Parse(number.Text), city.Text);
            backgroundWorker.RunWorkerAsync(temp);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { 
            lvUsers.ItemsSource = e.Result as List<Tester>;
            search.Visibility = Visibility.Collapsed;

         }
    
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Tester> items = (BL.FactoryBl.getBl().testers_area((Address)e.Argument));
            e.Result = items;
        }
    }
}
