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
    /// Interaction logic for slider_down_3.xaml
    /// </summary>
    public partial class slider_down_3 : UserControl
    {
        public slider_down_3()
        {
            InitializeComponent();
        }

        private void by_tests_num_Click(object sender, RoutedEventArgs e)
        {
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new by_tests_num());
        }

        private void by_teacher_click(object sender, RoutedEventArgs e)
        {
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new by_teacher());
        }

        private void by_school_click(object sender, RoutedEventArgs e)
        {
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new by_school());
        }

        private void by_tester_expertise_Click(object sender, RoutedEventArgs e)
        {
            MainWindow father = MainWindow.FindParentWindow(this);
            father.middle.Children.Clear();
            father.middle.Children.Add(new by_tester_expertise());
        }
    }
}
