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
            nannyAdd._startHour = new DateTime[6];
            nannyAdd._endHour = new DateTime[6];
            nannyAdd._workDays = new bool[6];
            thisGrid.DataContext = nannyAdd;
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {

                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    nannyAdd._startHour[0] = Convert.ToDateTime(start);
                    nannyAdd._endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {

                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    nannyAdd._startHour[1] = Convert.ToDateTime(start);
                    nannyAdd._endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {

                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    nannyAdd._startHour[2] = Convert.ToDateTime(start);
                    nannyAdd._endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {

                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    nannyAdd._startHour[3] = Convert.ToDateTime(start);
                    nannyAdd._endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {

                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    nannyAdd._startHour[4] = Convert.ToDateTime(start);
                    nannyAdd._endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {

                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    nannyAdd._startHour[5] = Convert.ToDateTime(start);
                    nannyAdd._endHour[5] = Convert.ToDateTime(end);
                }

                bl.addNanny(nannyAdd);
                nannyAdd = new BE.Nanny();
                this.DataContext = nannyAdd;
                MessageBox.Show("Nanny is added successfully");
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
