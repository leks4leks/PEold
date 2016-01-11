using Microsoft.Win32;
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
    /// Interaction logic for ResBusiness.xaml
    /// </summary>
    public partial class ResBusiness : UserControl
    {
        public ResBusiness()
        {
            InitializeComponent();
        }

        private void BalanceTableCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (BalanceSwitchCheck != null)
            {
                if ((bool)BalanceSwitchCheck.IsChecked)
                {
                    // Если чекнули - отобразить диаграмму
                    if (RB_Balance != null)
                    {
                        RB_Balance.Visibility = System.Windows.Visibility.Visible;
                    }
                    if (RB_Balance_Chart != null)
                    {
                        RB_Balance_Chart.Visibility = System.Windows.Visibility.Hidden;
                    }
                    BalanceSwitchCheck.ToolTip = "Отобразить диаграмму";
                }
                else
                {
                    if (RB_Balance != null)
                    {
                        RB_Balance.Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (RB_Balance_Chart != null)
                    {
                        RB_Balance_Chart.Visibility = System.Windows.Visibility.Visible;
                    }
                    BalanceSwitchCheck.ToolTip = "Отобразить таблицу";
                }
            }
        }
        
        private void ProfitLossReportSwitchCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (ProfitLossReportSwitchCheck != null)
            {
                if ((bool)ProfitLossReportSwitchCheck.IsChecked)
                {
                    // Если чекнули - отобразить диаграмму
                    if (RB_ProfitLossReport != null)
                    {
                        RB_ProfitLossReport.Visibility = System.Windows.Visibility.Visible;
                    }
                    if (RB_ProfitLossReport_Chart != null)
                    {
                        RB_ProfitLossReport_Chart.Visibility = System.Windows.Visibility.Hidden;
                    }
                    ProfitLossReportSwitchCheck.ToolTip = "Отобразить диаграмму";
                    ProfitLossReportItemsGrid.RowDefinitions[0].Height = new GridLength(550);
                }
                else
                {
                    if (RB_ProfitLossReport != null)
                    {
                        RB_ProfitLossReport.Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (RB_ProfitLossReport_Chart != null)
                    {
                        RB_ProfitLossReport_Chart.Visibility = System.Windows.Visibility.Visible;
                    }
                    ProfitLossReportSwitchCheck.ToolTip = "Отобразить таблицу";
                    ProfitLossReportItemsGrid.RowDefinitions[0].Height = new GridLength(RB_ProfitLossReport_Chart.ActualHeight);
                }
            }
        }

        private void BalanceExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
                {
                    FileName = "Результаты бизнеса.pdf",
                    Filter = "PDF (*.pdf)|*.pdf"
                };
            if (dialog.ShowDialog() == true)
            {
                if (System.IO.File.Exists(dialog.FileName))
                {
                    System.IO.File.Delete(dialog.FileName);
                }
                System.IO.File.Copy(String.Format("{0}/RB.pdf", System.AppDomain.CurrentDomain.BaseDirectory), dialog.FileName);
            }
        }
    }
}
