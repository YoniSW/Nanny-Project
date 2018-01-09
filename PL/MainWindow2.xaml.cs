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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void click_addNanny(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();

            //new MainWindow().Show();

            //TabControl.

            //new MainWindow().Sample;
            ////.SelectedIndex Show() ;
        }
    }
}
