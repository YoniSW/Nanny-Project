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

namespace PL
{
    /// <summary>
    /// Interaction logic for getContracts.xaml
    /// </summary>
    public partial class getContracts : Window
    {
        public BE.Contract nanny;
        public IEnumerable<BE.Contract> contract_list;
        public BL.IBL bl; // connect to BL layer

        public getContracts()
        {
            InitializeComponent();
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            try
            {
                allNanniesBox.ItemsSource = contract_list;
                contract_list = bl.getContracts();
                if (contract_list != null && contract_list.GetEnumerator().MoveNext())
                    allNanniesBox.ItemsSource = contract_list;

                else
                    throw new Exception("there is no contracts in database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void allNanniesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
