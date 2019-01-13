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
    /// Interaction logic for by_tester_expertise.xaml
    /// </summary>
    public partial class by_tester_expertise : UserControl
    {
        public by_tester_expertise()
        {
            InitializeComponent();
            IBL bl = BL.FactoryBl.getBl();
            List<Tester> new_group = new List<Tester>();
            foreach (var item in bl.by_tester_expertice(true))
            {
                foreach (Tester t in item)
                    new_group.Add(t);
            }
            lvUsers.ItemsSource = new_group;
        }
    }
}
