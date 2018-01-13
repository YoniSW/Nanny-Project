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
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for deleteMother.xaml
    /// </summary>
    public partial class deleteMother : Window
    {
        public BL.IBL bl;
        public BE.Mother DelMom;
        public IEnumerable<BE.Mother> nanny_list;

        public deleteMother()
        {
            InitializeComponent();
            DelMom = new BE.Mother();
            this.DataContext = DelMom;
            bl = BL.FactoryBL.GetBL();
            textBox.ItemsSource = bl.getAllMothers();
            textBox.DisplayMemberPath = "_momID";
        }


    private void textBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
        {
            try
            {
                DelMom = (Mother)textBox.SelectedItem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteMother(long.Parse(textBox.Text));
                MessageBox.Show("Mother was deleted successfully!");
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }
            catch (Exception Exeption)
            {
                MessageBox.Show(Exeption.Message);
            }
        }


    }
}
