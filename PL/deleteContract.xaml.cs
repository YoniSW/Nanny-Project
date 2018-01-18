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
    /// Interaction logic for deleteContract.xaml
    /// </summary>
    public partial class deleteContract : Window
    {
        public BL.IBL bl;
        public BE.Contract delCont;
        public IEnumerable<BE.Contract> cont_list;

        public deleteContract()
        {
            InitializeComponent();
            delCont = new BE.Contract();
            this.DataContext = delCont;
            bl = BL.FactoryBL.GetBL();
            textBox.ItemsSource = bl.getContracts();
            textBox.DisplayMemberPath = "_contractID";
        }

        private void textBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                try
                {
                    delCont = (Contract)textBox.SelectedItem;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteContract(delCont._contractID);
                MessageBox.Show("Contract was deleted successfully!");
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }
            catch (Exception Exeption)
            {
                MessageBox.Show(Exeption.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
