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
    /// Interaction logic for deleteMother.xaml
    /// </summary>
    public partial class deleteMother : Window
    {
        public BL.IBL bl;
        public deleteMother()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteMother(long.Parse(textBox.Text));
            }
            catch (Exception Exeption)
            {
                MessageBox.Show(Exeption.Message);
            }
        }
    }
}
