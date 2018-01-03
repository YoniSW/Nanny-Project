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


            // adding all functions



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.addContract(addContr);
            addCont = new BE.Contract();
            ContractGrid.DataContext = addCont;  // added a name to the grid
            MessageBox.Show("Contract is added successfully added!");
            this.Close();

            //try
            //{

            //}

            //catch (FormatException)
            //{
            //    MessageBox.Show("Check your input and try again");
            //}
            //catch (Exception ex)
            //{
            MessageBox.Show("the contract was added");
            //}
        }
    }
}
