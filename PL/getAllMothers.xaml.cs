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
    /// Interaction logic for getAllMothers.xaml
    /// </summary>
    public partial class getAllMothers : Window
    {
        public BE.Mother nanny;
        public IEnumerable<BE.Mother> mother_list;
        public BL.IBL bl; // connect to BL layer

        public getAllMothers()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            try
            {
                allNanniesBox.ItemsSource = mother_list;
                mother_list = bl.getAllMothers();
                if (mother_list != null && mother_list.GetEnumerator().MoveNext())
                    allNanniesBox.ItemsSource = mother_list;

                else
                    throw new Exception("no mother in database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void allNanniesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
