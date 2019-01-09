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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for all_testers.xaml
    /// </summary>
    public partial class all_testers : UserControl
    {
        public all_testers()
        {
            InitializeComponent();
            List<Tester> items = (BL.FactoryBl.getBl().all_tester());
            //items.Add(new Tester() { id = 1, last_name= "flyshman", first_name= "peer", phone= 0584509872, max_testPerWeek=4, date_of_birth= DateTime.Parse("january 1, 2001"),Gender=gender.male, tester_expertice=vehicle.private_vehicle, expirence=88, address= new Address("hzait",1,"bni darom") });
            lvUsers.ItemsSource = items;
        }
    }
}
