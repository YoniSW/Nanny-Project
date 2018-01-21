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
                child_list = bl.getKidsByMom(a => a._momID == addMom._momID);
                _childIDTextBox.ItemsSource = child_list;
                child = (Child)_childIDTextBox.SelectedItem;
                this.DataContext = child;
                _childIDTextBox.DisplayMemberPath = "_fullName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                nanny_list = bl.allCompatibleNannies(addMom);
                _nannyIDTextBox.ItemsSource = nanny_list;
                nanny = (Nanny)_nannyIDTextBox.SelectedItem;
                this.DataContext = nanny;
                _nannyIDTextBox.DisplayMemberPath = "_fullName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void relevantNannies_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid helpDataGrid = sender as DataGrid;
            if (helpDataGrid.SelectedIndex > -1) // grid in not empty
            {
                nanny = helpDataGrid.SelectedItem as BE.Nanny;
                addCont._isByHour = nanny._acceptByHour;
                if (nanny._acceptByHour)
                    addCont._ratePerHour = bl.getUpdatedRate(addCont._childID, nanny._nannyID, true);

                else
                    addCont._ratePerHour = bl.getUpdatedRate(addCont._childID, nanny._nannyID, false);

                addCont._nannyID = nanny._nannyID;

                _nannyIDTextBox.Text = Convert.ToString(nanny._nannyID);
                _isByHourCheckBox.IsChecked = nanny._acceptByHour;
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

        private void _nannyIDTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                try
                {
                    nanny = (Nanny)_nannyIDTextBox.SelectedItem;
                   // _nannyIDTextBox1.Text = nanny._nannyID;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void _childIDTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_childIDTextBox.SelectedIndex != -1)
            {
                addCont._childID = (long)_childIDTextBox.SelectedValue;
                relevantNannies_list.ItemsSource = bl.allCompatibleNannies((BE.Mother)momBox.SelectedItem);
                relevantNannies_list.SelectedValuePath = "_nannyID";
            }
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

        private void add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((bool)(_didSignCheckBox.IsChecked == false))
                    throw new Exception("contract cannot be made without a signature!");

                if ((bool)((_ratePerHourTextBox.IsEnabled == false) || (_ratePerMonthTextBox.IsEnabled == false)))
                    throw new Exception("you didnt choose a pament method!");

                if ((bool)((_endWorkDatePicker.SelectedDate <= _beginWorkDatePicker.SelectedDate)))
                    throw new Exception("the end work is before the start work!");
                bl.addContract(addCont);
                MessageBox.Show("Contract is successfully added!");
                _contractIDTextBox.Visibility = Visibility.Visible;
                uniqID.Visibility = Visibility.Visible;
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

        private void _isByHourCheckBox_Checked(object sender, RoutedEventArgs e)
        {

                _ratePerHourLabel.Visibility = Visibility.Visible;
                _ratePerHourTextBox.Visibility = Visibility.Visible;
        }

        private void _isByHourCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _ratePerHourLabel.Visibility = Visibility.Hidden;
            _ratePerHourTextBox.Visibility = Visibility.Hidden;
        }

        private void _didSignCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Addbutton.Visibility = Visibility.Visible;

        }

        private void _didSignCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Addbutton.Visibility = Visibility.Hidden;
        }




        //private void _ratePerHourLabel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    _ratePerHourLabel.Visibility = Visibility.Visible;
        //}

        //private void _ratePerHourTextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{

        //}
    }
}
