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
using BE;

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
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
            IdContract.ItemsSource = bl.getContracts();
            IdContract.DisplayMemberPath = "_contractID";
        }


        private void IdContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1))
                try
                {
                    contract = (Contract)IdContract.SelectedItem;
                    this.DataContext = IdContract;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
