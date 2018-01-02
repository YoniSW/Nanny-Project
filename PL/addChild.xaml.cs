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
        public BE.Child childAdd; // childAdd contians the child data
        public BL.IBL bl; // connect to BL layer

        public addChild()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            //_birthdayDatePicker.SelectedDate = DateTime.Today;
            childAdd = new BE.Child(); // create a new child
            thisGrid.DataContext = childAdd;  // activate grid
           
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bl.addChild(childAdd);
                childAdd = new BE.Child();
                thisGrid.DataContext = childAdd;
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

    }
}
