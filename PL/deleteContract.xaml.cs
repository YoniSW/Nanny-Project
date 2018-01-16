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
    /// Interaction logic for deleteContract.xaml
    /// </summary>
    public partial class deleteContract : Window
    {
        public BL.IBL bl;
        public deleteContract()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteContract(long.Parse(textBox.Text));
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
