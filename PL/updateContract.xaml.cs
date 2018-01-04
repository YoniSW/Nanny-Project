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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for updateContract.xaml
    /// </summary>
    public partial class updateContract : Window
    {
        public BL.IBL bl;
        public BE.Mother mom;
        public BE.Contract contract;
        public BE.Child child;

        public updateContract()
        {
            InitializeComponent();
            contract = new BE.Contract();
            thisGrid.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
