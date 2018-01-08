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

        public BE.Nanny getAllNanny;
        public BE.Nanny addA_Nanny;
        public BL.IBL bl;
        public IEnumerable<BE.Nanny> nanny_list;

        public updateNanny()
        {
            InitializeComponent();
            addA_Nanny = new BE.Nanny();
            addA_Nanny._startHour = new DateTime[6];
            addA_Nanny._endHour = new DateTime[6];
            addA_Nanny._workDays = new bool[6];
            bl = BL.FactoryBL.GetBL();
        }

        
        #region search Click
        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addA_Nanny = bl.getNanny(Convert.ToInt64(_nannyIDTextBox.Text));
                this.DataContext = addA_Nanny;
                MessageBox.Show("Nanny was found, you can continue updating...");

                if (addA_Nanny._workDays[0] == true)
                {
                    SunCheck.IsChecked = true;
                    SunStart.Value = addA_Nanny._startHour[0].ToUniversalTime();
                    SunEnd.Value = addA_Nanny._endHour[0].ToUniversalTime();
                }
                if (addA_Nanny._workDays[1] == true)
                {
                    MonCheck.IsChecked = true;
                    MonStart.Value = addA_Nanny._startHour[1].ToUniversalTime();
                    MonEnd.Value = addA_Nanny._endHour[1].ToUniversalTime();
                }
                if (addA_Nanny._workDays[2] == true)
                {
                    TueCheck.IsChecked = true;
                    TueStart.Value = addA_Nanny._startHour[2].ToUniversalTime();
                    TueEnd.Value = addA_Nanny._endHour[2].ToUniversalTime();
                }
                if (addA_Nanny._workDays[3] == true)
                {
                    WedCheck.IsChecked = true;
                    WedStart.Value = addA_Nanny._startHour[3].ToUniversalTime();
                    WedEnd.Value = addA_Nanny._endHour[3].ToUniversalTime();
                }
                if (addA_Nanny._workDays[4] == true)
                {
                    ThuCheck.IsChecked = true;
                    ThuStart.Value = addA_Nanny._startHour[4].ToUniversalTime();
                    ThuEnd.Value = addA_Nanny._endHour[4].ToUniversalTime();
                }
                if (addA_Nanny._workDays[5] == true)
                {
                    FriCheck.IsChecked = true;
                    FriStart.Value = addA_Nanny._startHour[5].ToUniversalTime();
                    FriEnd.Value = addA_Nanny._endHour[5].ToUniversalTime();
                }
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
#endregion

        #region button Click
        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[0] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[1] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[2] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[3] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[4] = true;
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[4] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    addA_Nanny._workDays[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Nanny._startHour[5] = Convert.ToDateTime(start);
                    addA_Nanny._endHour[5] = Convert.ToDateTime(end);
                }

                bl.updateNany(addA_Nanny);
                addA_Nanny = new BE.Nanny();
                this.DataContext = addA_Nanny;
                MessageBox.Show("Nanny was updated successfully!");
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
        #endregion



        public IEnumerable<BE.Nanny> nanny_list;

        private void GetNannyIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //combobox that shows all the nanny's
        {
            this.GetNannyIDComboBox.ItemsSource = nanny_list;
          //  var allnannies = bl.getAllNanny();
            
           // return bl.getAllNanny();
        }
    }
}
