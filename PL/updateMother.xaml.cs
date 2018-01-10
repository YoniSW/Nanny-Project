using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
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
    /// Interaction logic for updateMother.xaml
    /// </summary>
    public partial class updateMother : Window
    {
        public BE.Mother addA_Mother;
        public BE.Mother getAllMothers;
        public BL.IBL bl;
        public updateMother()
        {
            InitializeComponent();
            addA_Mother = new BE.Mother();
            addA_Mother._startHour = new DateTime[6];

            addA_Mother._endHour = new DateTime[6];
            addA_Mother._daysRequestMom = new bool[6];
            this.DataContext = addA_Mother;
            bl = BL.FactoryBL.GetBL();
            IdMother.ItemsSource = bl.getAllMothers();
                }

        private void IdMother_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                addA_Mother = (Mother)IdMother.SelectedItem;
                this.DataContext = addA_Mother;

                try
                {
                    // addA_Mother = bl.getMother(Convert.ToInt64(_momIDTextBox.Text)); 
                    thisGrid.DataContext = addA_Mother;
                    MessageBox.Show("Mother was found, you can continue updating");

                    if (addA_Mother._daysRequestMom[0] == true)
                    {
                        SunCheck.IsChecked = true;
                        SunStart.Value = addA_Mother._startHour[0].ToUniversalTime();
                        SunEnd.Value = addA_Mother._endHour[0].ToUniversalTime();
                    }
                    if (addA_Mother._daysRequestMom[1] == true)
                    {
                        MonCheck.IsChecked = true;
                        MonStart.Value = addA_Mother._startHour[1].ToUniversalTime();
                        MonEnd.Value = addA_Mother._endHour[1].ToUniversalTime();
                    }
                    if (addA_Mother._daysRequestMom[2] == true)
                    {
                        TueCheck.IsChecked = true;
                        TueStart.Value = addA_Mother._startHour[2].ToUniversalTime();
                        TueEnd.Value = addA_Mother._endHour[2].ToUniversalTime();
                    }
                    if (addA_Mother._daysRequestMom[3] == true)
                    {
                        WedCheck.IsChecked = true;
                        WedStart.Value = addA_Mother._startHour[3].ToUniversalTime();
                        WedEnd.Value = addA_Mother._endHour[3].ToUniversalTime();
                    }
                    if (addA_Mother._daysRequestMom[4] == true)
                    {
                        ThuCheck.IsChecked = true;
                        ThuStart.Value = addA_Mother._startHour[4].ToUniversalTime();
                        ThuEnd.Value = addA_Mother._endHour[4].ToUniversalTime();
                    }
                    if (addA_Mother._daysRequestMom[5] == true)
                    {
                        FriCheck.IsChecked = true;
                        FriStart.Value = addA_Mother._startHour[5].ToUniversalTime();
                        FriEnd.Value = addA_Mother._endHour[5].ToUniversalTime();
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
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[0] = Convert.ToDateTime(start);
                    addA_Mother._endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[1] = Convert.ToDateTime(start);
                    addA_Mother._endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[2] = Convert.ToDateTime(start);
                    addA_Mother._endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[3] = Convert.ToDateTime(start);
                    addA_Mother._endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[4] = true;
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[4] = Convert.ToDateTime(start);
                    addA_Mother._endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    addA_Mother._daysRequestMom[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    addA_Mother._startHour[5] = Convert.ToDateTime(start);
                    addA_Mother._endHour[5] = Convert.ToDateTime(end);
                }
                bl.updateMother(addA_Mother);
                MessageBox.Show("Mother was updated successfully!");
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
