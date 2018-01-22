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

namespace PL.Windows
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public BE.Child child;
        public IEnumerable<BE.Child> child_list;
        public BE.Mother mom;
        public IEnumerable<BE.Mother> mother_list;
        public BE.Nanny nanny;
        public IEnumerable<BE.Nanny> nanny_list;
        public BE.Contract conract;
        public IEnumerable<BE.Contract> contract_list;
        public BL.IBL bl;

        public Admin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            allchildrenBox.ItemsSource = child_list;
            child_list = bl.getAllChildren();
            if (child_list != null && child_list.GetEnumerator().MoveNext())
                allchildrenBox.ItemsSource = child_list;

            allmomBox.ItemsSource = mother_list;
            mother_list = bl.getAllMothers();
            if (mother_list != null && mother_list.GetEnumerator().MoveNext())
                allmomBox.ItemsSource = mother_list;

            allNanniesBox.ItemsSource = nanny_list;
            nanny_list = bl.getAllNanny();
            if (nanny_list != null /*&& nanny_list.GetEnumerator().MoveNext()*/)
                allNanniesBox.ItemsSource = nanny_list;
        }

        private void allmothersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void allNanniesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void allchildrenBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void changePass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
