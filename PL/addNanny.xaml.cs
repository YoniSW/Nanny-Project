﻿using System;
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

            _nannyBirthDatePicker.SelectedDate = DateTime.Today;
            nannyAdd = new BE.Nanny();
            nannyAdd._startHour = new DateTime[6];
            nannyAdd._endHour = new DateTime[6];
            nannyAdd._workDays = new bool[6];
            thisGrid.DataContext = nannyAdd;// conects the object with the wpf
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    nannyAdd._workDays[0] = true; //added
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[0] = Convert.ToDateTime(start);
                    nannyAdd._endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    nannyAdd._workDays[1] = true; //added
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[1] = Convert.ToDateTime(start);
                    nannyAdd._endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    nannyAdd._workDays[2] = true; //added
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[2] = Convert.ToDateTime(start);
                    nannyAdd._endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    nannyAdd._workDays[3] = true; //added
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[3] = Convert.ToDateTime(start);
                    nannyAdd._endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    nannyAdd._workDays[4] = true; //added
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[4] = Convert.ToDateTime(start);
                    nannyAdd._endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    nannyAdd._workDays[5] = true; //added
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    if (start > end)
                    { throw new Exception("the times you declared are not possible!"); }
                    if (start == end)
                    { throw new Exception("you choosed the dayes, but not the houres!"); }
                    nannyAdd._startHour[5] = Convert.ToDateTime(start);
                    nannyAdd._endHour[5] = Convert.ToDateTime(end);
                }

                bl.addNanny(nannyAdd);
                nannyAdd = new BE.Nanny();
                this.DataContext = nannyAdd;
                MessageBox.Show("Nanny is added successfully");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
