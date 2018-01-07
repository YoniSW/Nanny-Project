using System;
using System.Collections.Generic;
using System.Globalization;
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
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for addMother.xaml
    /// </summary>
    public partial class addMother : Window
    {
        public BE.Mother addMom; // addMom contians the moms data
        public BL.IBL bl; // connect to BL layer

        public addMother()
        {
            InitializeComponent();
            addMom = new BE.Mother();
            addMom._startHour = new DateTime[6];
            addMom._endHour = new DateTime[6];
            addMom._daysRequestMom = new bool[6];
            thisGrid.DataContext = addMom;
            bl = BL.FactoryBL.GetBL();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    if(start >= end)
                    { throw new Exception("the times you declared are not possible!"); }                    
                    addMom._startHour[0] = Convert.ToDateTime(start);
                    addMom._endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    if (start >= end)
                    { throw new Exception("the times you declared are not possible!"); }
                    addMom._startHour[1] = Convert.ToDateTime(start);
                    addMom._endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    if (start >= end)
                    { throw new Exception("the times you declared are not possible!"); }
                    addMom._startHour[2] = Convert.ToDateTime(start);
                    addMom._endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    if (start >= end)
                    { throw new Exception("the times you declared are not possible!"); }
                    addMom._startHour[3] = Convert.ToDateTime(start);
                    addMom._endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[4] = true;
                    var start =ThuStart.Value;
                    var end = ThuEnd.Value;
                    if (start >= end)
                    { throw new Exception("the times you declared are not possible!"); }
                    addMom._startHour[4] = Convert.ToDateTime(start);
                    addMom._endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    addMom._daysRequestMom[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    if (start >= end)
                    { throw new Exception("the times you declared are not possible!"); }
                    addMom._startHour[5] = Convert.ToDateTime(start);
                    addMom._endHour[5] = Convert.ToDateTime(end);
                }


                bl.addMother(addMom);
                addMom = new BE.Mother();
                thisGrid.DataContext = addMom;
                MessageBox.Show("Mother is added successfully!");
                this.Close();
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
