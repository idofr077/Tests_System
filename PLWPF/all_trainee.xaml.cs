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
    /// Interaction logic for all_trainee.xaml
    /// </summary>
    public partial class all_trainee : UserControl
    {
        public all_trainee()
        {
            InitializeComponent();
            List<Trainee> items = (BL.FactoryBl.getBl().all_trainee());
            //items.Add(new Trainee() { id = 2, last_name = "flyshman", first_name = "peer", phone = 0584509872, date_of_birth = DateTime.Parse("january 1, 2001"), Gender = gender.male, learn_vehicle = vehicle.heavy_track, gearbox=kind_of_gearbox.manual, num_of_test = 88,waiting_for_test=true, num_of_lessons=33, num_of_licenses=0, school="dd", teacher_name="shlomi", address = new Address("hzait", 1, "bni darom") });
            lvUsers.ItemsSource = items;

        }
    }
}
