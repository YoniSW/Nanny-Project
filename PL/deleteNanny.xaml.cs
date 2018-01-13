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
    /// Interaction logic for deleteNanny.xaml
    /// </summary>
    public partial class deleteNanny : Window
    {
        public BL.IBL bl;
        public BE.Nanny DelNan;
        public IEnumerable<BE.Child> nanny_list;

        public deleteNanny()
        {
            InitializeComponent();
            DelNan = new BE.Nanny();
            this.DataContext = DelNan;
            bl = BL.FactoryBL.GetBL();
            textBox.ItemsSource = bl.getAllNanny();
            textBox.DisplayMemberPath = "_nannyID";
        }


        private void textBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                try
                {
                    DelNan = (Nanny)textBox.SelectedItem;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteNanny(int.Parse(textBox.Text));
                MessageBox.Show("Nanny was deleted successfully!");
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


    }
}
