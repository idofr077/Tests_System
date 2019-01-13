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
    /// Interaction logic for by_teacher.xaml
    /// </summary>
    public partial class by_teacher : UserControl
    {
        public by_teacher()
        {
            InitializeComponent();
            IBL bl = BL.FactoryBl.getBl();
            List<Trainee> new_group = new List<Trainee>();
            foreach (var item in bl.by_teacher(true))
            {
                foreach (Trainee t in item)
                    new_group.Add(t);
            }
            lvUsers.ItemsSource = new_group;

        }
    }
}
