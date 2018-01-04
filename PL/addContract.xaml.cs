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

  
        public BE.Mother mom;
        public BE.Contract addCont; // addCont contians the contracts data
        public BE.Nanny nanny;
        public BE.Child child;
        // scan for relevant nanny's and kids 
        public IEnumerable<BE.Child> child_list;
        public IEnumerable<BE.Nanny> nanny_list;

        public BL.IBL bl; // connect to BL layer

        public addContract()
        {
            InitializeComponent();
            addCont = new BE.Contract();
            thisGrid.DataContext = addCont;
            bl = BL.FactoryBL.GetBL();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mom = bl.getMother(Convert.ToInt64(momID_textBox.Text)); // get thisMom's object
                child_list = bl.getKidsByMom(a => a._momID == mom._momID); // refine children list to thisMoms kids
                thisMomsKids_list.ItemsSource = child_list; // update UI window
                nanny_list = bl.allCompatibleNannies(mom); // refine to relevant nanneis (suitble schedule or 5 nearest)
                relevantNannies_list.ItemsSource = nanny_list; // update UI window
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

        private void add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bl.addContract(addCont);
                MessageBox.Show("Contract is successfully added!");
                this.Close();
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

        private void relevantNannies_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid helpDataGrid = sender as DataGrid;
            if ( helpDataGrid.SelectedIndex > 0) // grid in not empty
            {
                nanny =  helpDataGrid.SelectedItem as BE.Nanny;
                _nannyIDTextBox.Text = Convert.ToString(nanny._nannyID);
                _isByHourCheckBox.IsChecked = nanny._acceptByHour;
                if (nanny._acceptByHour)
                    _ratePerHourTextBox.Text = Convert.ToString(bl.getUpdatedRate(child._childID, nanny._nannyID, true));

                _ratePerHourTextBox.Text = Convert.ToString(bl.getUpdatedRate(child._childID, nanny._nannyID, false));
                addCont._nannyID = nanny._nannyID;
            }
        }

        private void thisMomsKids_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid helpDataGrid = sender as DataGrid;
            if (helpDataGrid.SelectedIndex > 0) // grid in not empty
            {
                child = helpDataGrid.SelectedItem as BE.Child;
                _childIDTextBox.Text = Convert.ToString(child._childID);
                addCont._childID = child._childID;
            }

        }
    }
}
