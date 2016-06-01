using ProgressoExpert.Models.Models;
using ProgressoExpert.Process;
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

namespace ProgressoExpert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ViewModel = new MainModel();
            MenuControl.DataContext = MenuControl.ViewModel = ViewModel;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ViewModel.StartDate = DateTime.Today; //;(DateTime)StartDate.SelectedDate;
            ViewModel.EndDate = DateTime.Today; // (DateTime)endDate.SelectedDate;
            //return;

            ViewModel.StartDate = new DateTime(2013, 10, 01);
            ViewModel.EndDate = new DateTime(2014, 02, 01);
            //алешкин код
            ViewModel = ProcessesEngine.InitMainModel(ViewModel.StartDate, ViewModel.EndDate);
            ViewModel.LiveStreamModel = ProcessesEngine.GetLiveStream(ViewModel.StartDate, ViewModel.EndDate);

            ViewModel.InfoModel.CurrencyRateList = CurrencyRates.GetExchangeRates();
            ViewModel.InfoModel.StartTimer2();
            HeaderControl.DataContext = ViewModel.InfoModel;

            LiveStreamControl.DataBind(ViewModel.LiveStreamModel);
        }

        private void DataBind()
        {
            MenuControl.DataBind(ViewModel);
        }

        public void UpdateData()
        {
            // Результаты бизнеса
            ViewModel.BusinessResults = ProcessesEngine.GetBusinessResults(ViewModel);
            ViewModel.ReportProfitAndLoss = ProcessesEngine.GetReportProfitAndLoss(ViewModel);
            ViewModel.RatiosIndicatorsResult = ProcessesEngine.GetRatiosIndicatorsResult(ViewModel);

            ViewModel.EndDate = new DateTime(ViewModel.EndDate.Year, ViewModel.EndDate.Month, ViewModel.EndDate.Day); 
            // Бизнес Анализ
            //ViewModel.GeneralBA = ProcessesEngine.GetGeneralBusinessAnalysis(ViewModel.StartDate, ViewModel.EndDate, ViewModel);
            //ViewModel.ProfitBA = ProcessesEngine.GetProfitBA(ViewModel);
            //ViewModel.SalesBA = ProcessesEngine.GetSalesBA(ViewModel);
            //ViewModel.CostsBA = ProcessesEngine.GetCostsBA(ViewModel);
            //ViewModel.PurchaseBA = ProcessesEngine.GetPurchaseBA(ViewModel);
            //ViewModel.WorkingСapitalBA = ProcessesEngine.GetWorkingСapitalBA(ViewModel);

            // Стресс-тестирование


            // Биндинг
            //BusinessAnalysisControl.DataBind(ViewModel);

            ResBusinessControl.DataBind(ViewModel);
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            foreach (var item in Application.Current.Windows)
            {
                (item as Window).Close();
            }
        }
    }
}
