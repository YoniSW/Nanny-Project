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
    /// Interaction logic for addChild.xaml
    /// </summary>
    public partial class addChild : Window
    {
        public BE.Mother mom;
        public BE.Child childAdd; // childAdd contians the child data
        public BL.IBL bl; // connect to BL layer

        public addChild()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
 

            comboBoxMom.ItemsSource = bl.getAllMothers();
            comboBoxMom.DisplayMemberPath = "_fullName";
            comboBoxMom.SelectedIndex = -1;

            childAdd = new BE.Child(); // create a new child
            thisGrid.DataContext = childAdd;  // activate grid


        }


        private void comboBoxMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mom = (BE.Mother)comboBoxMom.SelectedItem;
            if (mom != null)
                _momIDTextBox.Text = Convert.ToString(mom._momID);
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bl.addChild(childAdd);
                childAdd = new BE.Child();
                thisGrid.DataContext = childAdd;
                comboBoxMom.SelectedIndex = -1;
                MessageBox.Show("Child was added successfully!");
                Close();
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

        //private void comboBoxChoseMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    comboBoxChoseChild.ItemsSource = bl.getAllChildren(a => a._momID == Convert.ToInt64(comboBoxMom.SelectedValue));
        //    comboBoxChoseChild.DisplayMemberPath = "fullName";
        //    comboBoxChoseChild.SelectedValuePath = "idChild";
        //    comboBoxChoseChild.SelectedIndex = -1;
        //}

        //private void comboBoxChoseChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    child = (BE.Child)comboBoxChoseChild.SelectedItem;
        //    updateChildTab.DataContext = child;
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void nameCheck_Checked(object sender, RoutedEventArgs e)
        {
            comboBoxMom.DisplayMemberPath = "_fullName";
            IDcheck.IsChecked = false;
        }

        private void IDcheck_Checked(object sender, RoutedEventArgs e)
        {
            comboBoxMom.DisplayMemberPath = "_momID";
            nameCheck.IsChecked = false;

        }
    }
}
