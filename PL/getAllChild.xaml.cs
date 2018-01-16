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
    /// Interaction logic for getAllChild.xaml
    /// </summary>
    public partial class getAllChild : Window
    {
        public BE.Child child;
        public IEnumerable<BE.Child> child_list;
        public BL.IBL bl; // connect to BL layer

        public getAllChild()
        {
            
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            try
            {
                allNanniesBox.ItemsSource = child_list;
                child_list = bl.getAllChildren();
                if (child_list != null && child_list.GetEnumerator().MoveNext())
                    allNanniesBox.ItemsSource = child_list;

                else
                    throw new Exception("no children in database");
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
