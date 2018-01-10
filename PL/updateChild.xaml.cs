using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using BL;
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
    /// Interaction logic for updateChild.xaml
    /// </summary>
    public partial class updateChild : Window
    {
        public BE.Child updateKid;
        public BL.IBL bl;
        public BE.Child getAllChild;
        public IEnumerable<BE.Child> child_list;


        public updateChild()
        {
            InitializeComponent();
            this.DataContext = updateKid;
            bl = BL.FactoryBL.GetBL();
            IdChild.ItemsSource = bl.getAllChildren();
        }

        private void IdChild_SelectionChanged(object tempo, RoutedEventArgs e)
        {
            if (tempo is ComboBox && ((ComboBox)tempo).SelectedIndex > -1)
            try
            {
               updateKid = (Child)IdChild.SelectedItem;
                this.DataContext = updateKid;
                MessageBox.Show("Child is found, you can continue updating...");
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

        private void update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateKid = thisGrid.DataContext as Child; // save new data as a Child object
                bl.updateChild(updateKid);
                MessageBox.Show("Child information is updated");
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
    }
}
