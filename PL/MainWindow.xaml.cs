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

       public void click_addNanny(object sender, RoutedEventArgs e)
        {
            addNanny add = new addNanny();
            add.show();
        }

        public void click_deleteNanny(object sender, RoutedEventArgs e)
        {
            deleteNanny add = new deleteNanny();
            add.Show();
        }


    }
}
