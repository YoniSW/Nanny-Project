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
using System.Windows.Shapes;
using BL;
using BE;
using PL.Windows;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow2 : Window
    {

        public MainWindow2()
        {
            InitializeComponent();
        }

        private void NannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window Tabs = new MainWindow(0);
            Close();
            Tabs.ShowDialog();   
        }

        private void Motherbutton_Click(object sender, RoutedEventArgs e)
        {
            Window Tabs = new MainWindow(1);
            Close();
            Tabs.ShowDialog();
            
        }
        private void ChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window Tabs = new MainWindow(2);
            Close();
            Tabs.ShowDialog();
            
        }
        private void ContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window Tabs = new MainWindow(3);
            Tabs.ShowDialog();
            Close();

            
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            
            var pass = new Password();
            pass.ShowDialog();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }


    }
}
