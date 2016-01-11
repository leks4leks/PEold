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

namespace ProgressoExpert.Controls.ResBusines
{
    /// <summary>
    /// Interaction logic for RB_ProfitLossReport1.xaml
    /// </summary>
    public partial class RB_ProfitLossReport : UserControl
    {
        public RB_ProfitLossReport()
        {
            InitializeComponent();
        }

        private void dataProfitLossReportGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (rowProfitLossReportGrid).ScrollToHorizontalOffset(scrollViewer.HorizontalOffset);
            (stProfitLossReportGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
            (nodataProfitLossReportGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void stProfitLossReportGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (dataProfitLossReportGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
            (nodataProfitLossReportGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }
    }
}
