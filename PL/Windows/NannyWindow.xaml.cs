﻿using BE;
using BL;
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
    public partial class NannyWindow :Window
    {
        public BE.Nanny nannyAdd; // nannydAdd contians the child data
        public BL.IBL bl; // connect to BL layer

        public NannyWindow(int tabIndex)
        {
            InitializeComponent();
            
            NannyTabs.SelectedIndex = tabIndex;
        }

        //public NannyWindow()
        //{
        //    InitializeComponent();
        //}


        

        public NannyWindow()
        {
            InitializeComponent();

            _nannyBirthDatePicker.SelectedDate = DateTime.Today;
            nannyAdd = new BE.Nanny();
            nannyAdd._startHour = new DateTime[6];
            nannyAdd._endHour = new DateTime[6];
            nannyAdd._workDays = new bool[6];
            this.DataContext = nannyAdd;// conects the object with the wpf
            bl = BL.FactoryBL.GetBL();
        }

        #region Add Nanny Tab
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
        #endregion



        #region Update Nanny Tab
        //public partial class updateNanny : Window
        //{
            public BE.Nanny addA_Nanny;
            //public BL.IBL bl;
            public IEnumerable<BE.Nanny> nanny_list;

            public void updateNanny()
            {
                InitializeComponent();

                _nannyBirthDatePicker2.SelectedDate = DateTime.Today;
                addA_Nanny = new BE.Nanny();
                addA_Nanny._startHour = new DateTime[6];
                addA_Nanny._endHour = new DateTime[6];
                addA_Nanny._workDays = new bool[6];
                this.DataContext = addA_Nanny;
                bl = BL.FactoryBL.GetBL();
                IdNanny.ItemsSource = bl.getAllNanny();
            }


            #region SelectionChanged
            private void IdNanny_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                {
                    try
                    {
                        addA_Nanny = (Nanny)IdNanny.SelectedItem;
                        thisGrid.DataContext = addA_Nanny;


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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
            #endregion

            #region button Click
            private void button_Click1(object sender, RoutedEventArgs e)
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

                    bl.updateNanny(addA_Nanny);
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
        #endregion
    }

}



