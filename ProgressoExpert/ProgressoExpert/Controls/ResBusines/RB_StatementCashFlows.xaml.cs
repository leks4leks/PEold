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
    /// Interaction logic for RB_StatementCashFlows.xaml
    /// </summary>
    public partial class RB_StatementCashFlows : UserControl
    {
        public RB_StatementCashFlows()
        {
            InitializeComponent();
        }

        private void dataStatementCashFlowsGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (rowStatementCashFlowsGrid).ScrollToHorizontalOffset(scrollViewer.HorizontalOffset);
            (stStatementCashFlowsGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
            (nodataStatementCashFlowsGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void stStatementCashFlowsGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (dataStatementCashFlowsGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
            (nodataStatementCashFlowsGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }
    }
}
