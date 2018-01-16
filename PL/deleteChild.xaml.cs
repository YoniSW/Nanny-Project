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
    /// Interaction logic for deleteChild.xaml
    /// </summary>
    public partial class deleteChild : Window
    {
        public BL.IBL bl;
        public BE.Child DelChild;
        public IEnumerable<BE.Child> child_list;

        public deleteChild()
        {
            InitializeComponent();
            DelChild = new BE.Child();
            this.DataContext = DelChild;
            bl = BL.FactoryBL.GetBL();
            textBox.ItemsSource = bl.getAllChildren(); 
            textBox.DisplayMemberPath = "_childID";

        }

        private void textBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                try
                {
                    DelChild = (Child)textBox.SelectedItem;

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
                bl.deleteChild(DelChild._childID);
                MessageBox.Show("Child was deleted successfully!");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
