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

    public partial class getAllNannies : Window
    {
        public BE.Nanny nanny;
        public IEnumerable<BE.Nanny> nanny_list;
        public BL.IBL bl; // connect to BL layer

        public getAllNannies()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            try
            {
                allNanniesBox.ItemsSource = nanny_list;
                nanny_list = bl.getAllNanny();
                if (nanny_list != null && nanny_list.GetEnumerator().MoveNext())
                    allNanniesBox.ItemsSource = nanny_list;

                else
                    throw new Exception("no nannies in database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void allNanniesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
