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
    /// Interaction logic for deleteChild.xaml
    /// </summary>
    public partial class deleteChild : Window
    {
        public BL.IBL bl;
        public deleteChild()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteChild(long.Parse(textBox.Text));
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
    }
}
