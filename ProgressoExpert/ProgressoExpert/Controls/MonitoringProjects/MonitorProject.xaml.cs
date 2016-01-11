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

namespace ProgressoExpert.Controls.MonitoringProjects
{
    /// <summary>
    /// Interaction logic for MonitorProject.xaml
    /// </summary>
    public partial class MonitorProject : UserControl
    {
        public MonitorProject()
        {
            InitializeComponent();
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (dataMonitorProjectGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void dataStatementCashFlowsGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            (rowMonitorProjectGrid).ScrollToHorizontalOffset(scrollViewer.HorizontalOffset);
            (stMonitorProjectGrid).ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void Exp1_Collapsed(object sender, RoutedEventArgs e)
        {
            btnExport.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Exp1_Expanded(object sender, RoutedEventArgs e)
        {
            btnExport.Visibility = System.Windows.Visibility.Visible;
        }

        private void dataMonitorProjectGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollControl = sender as ScrollViewer;
            if (!e.Handled && sender != null)
            {
                if ((e.Delta > 0 && scrollControl.VerticalOffset == 0)
                    || (e.Delta <= 0 && scrollControl.VerticalOffset >= scrollControl.ExtentHeight - scrollControl.ViewportHeight))
                {
                    e.Handled = true;
                    var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                    eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                    eventArg.Source = sender;
                    var parent = ((Control)sender).Parent as UIElement;
                    parent.RaiseEvent(eventArg);
                }
            }
        }
    }
}
