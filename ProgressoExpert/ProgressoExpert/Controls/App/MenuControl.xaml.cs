using ProgressoExpert.Controls.Calculators;
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

        CalculatorWindow CalculatorWindow;
        DepositCalculatorWindow DepositCalculatorWindow;
        AnnCreditCalculatorWindow AnnCreditCalculatorWindow;
        CreditCalculatorWindow CreditCalculatorWindow;

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
                /*ForecastBtn.IsChecked = */false;

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
            //else if ((sender as ToggleButton) == ForecastBtn)
            //{
            //    ForecastBtn.IsChecked = ViewModel2.ForecastVisibility = true;
            //}
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CreditCalculatorWindow == null)
            {
                CreditCalculatorWindow = new CreditCalculatorWindow();
            }
            CreditCalculatorWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CalculatorWindow == null)
            {
                CalculatorWindow = new CalculatorWindow();
            }
            CalculatorWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (DepositCalculatorWindow == null)
            {
                DepositCalculatorWindow = new DepositCalculatorWindow();
            }
            DepositCalculatorWindow.Show();
        }
    }
}
