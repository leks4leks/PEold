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
        SelectPeriod SelectPeriodWindow;

        public MenuControl()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = model;
            this.DataContext = ViewModel;
        }


        private void MenuBtns_Checked(object sender, RoutedEventArgs e)
        {
            CheckedOrUnchecked(sender);
        }

        public void CheckedOrUnchecked(object sender)
        {
            LiveStreamBtn.IsChecked = 
                BusinessAnalysisBtn.IsChecked = 
                StressTestingBtn.IsChecked = 
                BusinessResultsBtn.IsChecked = 
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
            MainWindow win = (MainWindow)Window.GetWindow(this);
            if (SelectPeriodWindow == null)
            {
                SelectPeriodWindow = new SelectPeriod(ViewModel, win);
            }
            SelectPeriodWindow.Show();
        }
    }
}
