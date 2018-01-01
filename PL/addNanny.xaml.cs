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
    public partial class addNanny : Window
    {
        public BE.Nanny nannyAdd; // nannydAdd contians the child data
        public BL.IBL bl; // connect to BL layer

        public addNanny()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            try
            {
                bl.addNanny(nannyAdd);
                nannyAdd = new BE.Nanny();
                this.DataContext = nannyAdd;
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
