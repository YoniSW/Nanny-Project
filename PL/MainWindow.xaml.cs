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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// nanny

        private void click_addNanny(object sender, RoutedEventArgs e)
        {
            addNanny add = new addNanny();
            add.Show();
        }

        private void click_deleteNanny(object sender, RoutedEventArgs e)
        {
            deleteNanny add = new deleteNanny();
            add.Show();
        }

        private void click_updateNanny(object sender, RoutedEventArgs e)
        {
            updateNanny add = new updateNanny();
            add.Show();
        }

        private void click_getAllNannies(object sender, RoutedEventArgs e)
        {
            getAllNannies add = new getAllNannies();
            add.Show();
        }

        /// mother

        private void click_addMother(object sender, RoutedEventArgs e)
        {
            addMother add = new addMother();
            add.Show();
        }

        private void click_deleteMother(object sender, RoutedEventArgs e)
        {
            deleteMother add = new deleteMother();
            add.Show();
        }

        private void click_updateMother(object sender, RoutedEventArgs e)
        {
            updateMother add = new updateMother();
            add.Show();
        }

        private void click_getAllMothers(object sender, RoutedEventArgs e)
        {
            getAllMothers add = new getAllMothers();
            add.Show();
        }

        /// mother

        private void click_addChild(object sender, RoutedEventArgs e)
        {
            addChild add = new addChild();
            add.Show();
        }

        private void click_deleteChild(object sender, RoutedEventArgs e)
        {
            deleteChild add = new deleteChild();
            add.Show();
        }

        private void click_updateChild(object sender, RoutedEventArgs e)
        {
            updateChild add = new updateChild();
            add.Show();
        }

        private void click_getKidsByMom(object sender, RoutedEventArgs e)
        {
            getAllChild add = new getAllChild();
            add.Show();
        }

        private void click_getContracs(object sender, RoutedEventArgs e)
        {
            getContracts add = new getContracts();
            add.Show();
        }

        
        private void click_addContract(object sender, RoutedEventArgs e)
        {
            addContract add = new addContract();
            add.Show();
        }

        
        private void click_updateContract(object sender, RoutedEventArgs e)
        {
            updateContract add = new updateContract();
            add.Show();
        }

        
        private void click_deleteContract(object sender, RoutedEventArgs e)
        {
            deleteContract add = new deleteContract();
            add.Show();
        }
    }


}
