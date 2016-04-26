using ProgressoExpert.Models.Models;
using ProgressoExpert.Models.Models.App;
using ProgressoExpert.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.App
{
    /// <summary>
    /// Логика взаимодействия для MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        public MainModel ViewModel;

        public MenuControl()
        {
            InitializeComponent();
        }

        private void MenuBtns_Checked(object sender, RoutedEventArgs e)
        {
            CheckedOrUnchecked(sender);
        }

        public void CheckedOrUnchecked(object sender)
        {
            LiveStreamBtn.IsChecked = false;
            BusinessAnalysisBtn.IsChecked = false;
            StressTestingBtn.IsChecked = false;
            BusinessResultsBtn.IsChecked = false;
            ForecastBtn.IsChecked = false;

            if ((sender as ToggleButton) == LiveStreamBtn)
            {
                LiveStreamBtn.IsChecked = ViewModel.LiveStreamVisibility = true;
            }
            else if ((sender as ToggleButton) == BusinessAnalysisBtn)
            {
                BusinessAnalysisBtn.IsChecked = ViewModel.BusinessAnalysisVisibility = true;
            }
            else if ((sender as ToggleButton) == StressTestingBtn)
            {
                StressTestingBtn.IsChecked = ViewModel.StressTestingVisibility = true;
            }
            else if ((sender as ToggleButton) == BusinessResultsBtn)
            {
                BusinessResultsBtn.IsChecked = ViewModel.ResBusinessVisibility = true;
            }
            else if ((sender as ToggleButton) == ForecastBtn)
            {
                ForecastBtn.IsChecked = ViewModel.ForecastVisibility = true;
            }
        }

        private void ShowUpdatePanelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ResBusinessVisibility)
            {
                //TODO чота сделать
                var stTodayDate = new DateTime(2013, 02, 01);
                var endTodayDate = DateTime.Today;
                var tmp = ProcessesEngine.GetResult(stTodayDate, endTodayDate);
                ViewModel.BusinessResults = tmp.BusinessResults;
                ViewModel.ReportProfitAndLoss = tmp.ReportProfitAndLoss;
                ViewModel.Sales = tmp.Sales;
                ViewModel.RatiosIndicatorsResult = tmp.RatiosIndicatorsResult;
                ViewModel.ADDSTranz = tmp.ADDSTranz;
            }
        }
    }
}
