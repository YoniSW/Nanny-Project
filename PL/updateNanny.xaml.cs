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
    /// Interaction logic for updateNanny.xaml
    /// </summary>
    public partial class updateNanny : Window
    {

        public BE.Nanny addA_Nanny;
        public BL.IBL bl;

        public updateNanny()
        {
            InitializeComponent();
            addA_Nanny = new BE.Nanny();
            addA_Nanny._startHour = new DateTime[6];
            addA_Nanny._endHour = new DateTime[6];
            addA_Nanny._workDays = new bool[6];
            //updateNannyDeatails.DataContext = addA_Nanny;  --> grid we wnat to update
            bl = BL.FactoryBL.GetBL();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addA_Nanny = bl.getNanny(Convert.ToInt64(_nannyIDTextBox.Text));
                thisGrid.DataContext = addA_Nanny;
                MessageBox.Show("Nanny is found, you can continue updating...");
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {


            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
