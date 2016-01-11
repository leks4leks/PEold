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

namespace ProgressoExpert.Controls.BusinessIndicators
{
    /// <summary>
    /// Interaction logic for BusIndicator.xaml
    /// </summary>
    public partial class BusIndicator : UserControl
    {
        public BusIndicator()
        {
            InitializeComponent();
        }

        private void Exp1_Collapsed(object sender, RoutedEventArgs e)
        {
            btnExport.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Exp1_Expanded(object sender, RoutedEventArgs e)
        {
            btnExport.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
