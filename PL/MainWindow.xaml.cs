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
          new addNanny().Show();
        }

        private void click_deleteNanny(object sender, RoutedEventArgs e)
        {
            new deleteNanny().Show();
        }

        private void click_updateNanny(object sender, RoutedEventArgs e)
        {
           new updateNanny().Show();
        }

        private void click_getAllNannies(object sender, RoutedEventArgs e)
        {
            new getAllNannies().ShowDialog();
        }

        /// mother

        private void click_addMother(object sender, RoutedEventArgs e)
        {
            new addMother().Show();
        }

        private void click_deleteMother(object sender, RoutedEventArgs e)
        {
            new deleteMother().Show();
        }

        private void click_updateMother(object sender, RoutedEventArgs e)
        {
            new updateMother().Show();
        }

        private void click_getAllMothers(object sender, RoutedEventArgs e)
        {
            new getAllMothers().ShowDialog();
        }

        /// mother

        private void click_addChild(object sender, RoutedEventArgs e)
        {
            new addChild().Show();
        }

        private void click_deleteChild(object sender, RoutedEventArgs e)
        {
            new deleteChild().Show();
        }

        private void click_updateChild(object sender, RoutedEventArgs e)
        {
           new updateChild().Show();
        }

        private void click_getKidsByMom(object sender, RoutedEventArgs e)
        {
            new getAllChild().ShowDialog();
        }

        // contract

        private void click_getContracs(object sender, RoutedEventArgs e)
        {
            new getContracts().ShowDialog();
        }

        
        private void click_addContract(object sender, RoutedEventArgs e)
        {
            new addContract().Show();
        }

        
        private void click_updateContract(object sender, RoutedEventArgs e)
        {
          new updateContract().Show();
        }

        
        private void click_deleteContract(object sender, RoutedEventArgs e)
        {
           new deleteContract().Show();
        }
    }


}
