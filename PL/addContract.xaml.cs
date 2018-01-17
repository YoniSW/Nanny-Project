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

        public BE.Mother addMom;
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
            addMom = new BE.Mother();
            thisGrid.DataContext = addCont;
            bl = BL.FactoryBL.GetBL();
            momBox.ItemsSource = bl.getAllMothers();
           momBox.DisplayMemberPath = "_fullName";
        }

        private void momBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                addMom = (Mother)momBox.SelectedItem;
                this.DataContext = addMom;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                child_list = bl.getKidsByMom(a => a._momID == addMom._momID); // refine children list to thisMoms kids
                thisMomsKids_list.ItemsSource = child_list; // update UI window
                nanny_list = bl.allCompatibleNannies(addMom); // refine to relevant nanneis (suitble schedule or 5 nearest)
                relevantNannies_list.ItemsSource = nanny_list; // update UI window
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

        private void add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((bool)(_didSignCheckBox.IsChecked == false))
                   throw new Exception("contract cannot be made without a signature!");

                if ((bool)((_ratePerHourTextBox.IsEnabled == false)|| (_ratePerMonthTextBox.IsEnabled == false)))
                    throw new Exception("you didnt choose a pament method!");

                if ((bool)((_endWorkDatePicker.SelectedDate <= _beginWorkDatePicker.SelectedDate)))
                    throw new Exception("the end work is before the start work!");
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
                MessageBox.Show(ex.Message);
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
            // add NANNY?
            nanny = new BE.Nanny();
            grid1.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
            _nannyIDTextBox.ItemsSource = nanny_list;
            _nannyIDTextBox.DisplayMemberPath = "_nannyID";
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

        private void _nannyIDTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                try
                {
                    nanny = (Nanny)_nannyIDTextBox.SelectedItem;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void _childIDTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void nameCheck_Checked(object sender, RoutedEventArgs e)
        {
            momBox.DisplayMemberPath = "_fullName";
            IDcheck.IsChecked = false;
        }

        private void IDcheck_Checked(object sender, RoutedEventArgs e)
        {
            momBox.DisplayMemberPath = "_momID";
            nameCheck.IsChecked = false;

        }
    }
}
