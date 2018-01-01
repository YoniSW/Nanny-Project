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

            try
            {
                bl.addChild(childAdd);
                childAdd = new BE.Child();
                this.DataContext = childAdd;
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
