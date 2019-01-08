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
    /// Interaction logic for all_tests.xaml
    /// </summary>
    public partial class all_tests : UserControl//
    {
        public all_tests()
        {
            InitializeComponent();
            List<Test> items = new List<Test>();
            items.Add(new Test() {id=5, id_tester=1,id_trainee=2, date=DateTime.Parse("january 15, 2019"), address=new Address("bne brit",2,"ashdod"), distance=null,reverse=null, mirrors=null,signals=null, crosswalk = null, grade=null, mention="good"});
            lvUsers.ItemsSource = items;
        }
    }
}
