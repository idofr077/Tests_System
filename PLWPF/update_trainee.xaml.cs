﻿using System;
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
    /// Interaction logic for update_trainee.xaml
    /// </summary>
    public partial class update_trainee : UserControl
    {
        public update_trainee()
        {
            InitializeComponent();
            List<int> idis = new List<int>();
            for (int i = 0; i < BL.FactoryBl.getBl().all_trainee().Count; i++)
            {
                idis.Add(BL.FactoryBl.getBl().all_trainee()[i].id);
            }
            id.ItemsSource = idis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
