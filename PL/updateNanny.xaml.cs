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
    /// Interaction logic for updateNanny.xaml
    /// </summary>
    public partial class updateNanny : Window
    {

        public BE.Nanny nannyToUpdate;
        public BL.IBL bl;

        public updateNanny()
        {
            InitializeComponent();
            nannyToUpdate = new BE.Nanny();
            nannyToUpdate._startHour = new DateTime[6];
            nannyToUpdate._endHour = new DateTime[6];
            nannyToUpdate._workDays = new bool[6];
            //updateNannyDeatails.DataContext = nannyToUpdate;  --> grid we wnat to update
            bl = BL.FactoryBL.GetBL();
        }

        private void click_search(object sender, RoutedEventArgs e)
        {
            nannyToUpdate = bl.getNanny(Convert.ToInt64(nannyIdTextBox.Text));
        }

    }
}
