using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for addMother.xaml
    /// </summary>
    public partial class addMother : Window
    {
        public BE.Mother addMom;
        public BL.IBL bl;

        public addMother()
        {
            InitializeComponent();
            addMom = new BE.Mother();
            addMom._startHour = new DateTime[6];
            addMom._endHour = new DateTime[6];
            addMom._daysRequestMom = new bool[6];
            
            bl = BL.FactoryBL.GetBL();
        }

 
    }
}
