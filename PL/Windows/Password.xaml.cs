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

namespace PL.Windows
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public BL.IBL bl;
        public Password()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (password.Text == bl.getPass())
            {
                Close();
                var admin = new Admin();
                admin.ShowDialog();
            }
            else
                MessageBox.Show("Password is wrong!");
        }
    }
}
