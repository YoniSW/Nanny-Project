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
    /// Interaction logic for changePass.xaml
    /// </summary>
    public partial class changePass : Window
    {
        public BL.IBL bl;

        public changePass()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                if (oldPass.Text != bl.getPass())
                    throw new Exception("Old password is wrong");

                if (newPass1.Text != newPass2.Text)
                  throw new Exception("New password is not identical");

                bl.changePass(newPass1.Text);

                MessageBox.Show("Password updated successfully");

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
