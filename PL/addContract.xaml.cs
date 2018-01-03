using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for addContract.xaml
    /// </summary>
    public partial class addContract : Window
    {

        public BE.Contract addCont; // addCont contians the contracts data
        public BL.IBL bl; // connect to BL layer
        private readonly Contract addContr;

        public addContract()
        {
            InitializeComponent();
            addCont = new BE.Contract();

            // adding all exeptions

            // theis nanny does not exist 
            // this child does not exist
            // the end work is before the start work
            // contract cannot be made without a signature
            // you didnt rate the sallary            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.addContract(addContr);
            addCont = new BE.Contract();
            ContractGrid.DataContext = addCont;  // added a name to the grid
            MessageBox.Show("Contract is successfully added!");
            this.Close();

            try
            {
                if ((bool)(_didSignCheckBox.IsChecked == false))
                    MessageBox.Show("contract cannot be made without a signature!");

                if ((bool)((_ratePerHourTextBox.IsEnabled == false)|| (_ratePerMonthTextBox.IsEnabled == false)))
                     MessageBox.Show("you didnt choose a pament method!");
            }

            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show("the contract was added");
            }
        }

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
