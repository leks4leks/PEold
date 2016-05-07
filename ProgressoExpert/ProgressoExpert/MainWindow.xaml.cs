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
            HeaderControl.DataContext = ViewModel.InfoModel;
            MenuControl.DataContext = MenuControl.ViewModel = ViewModel;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ViewModel.StartDate = DateTime.Today; //;(DateTime)StartDate.SelectedDate;
            ViewModel.EndDate = DateTime.Today; // (DateTime)endDate.SelectedDate;
            //return;

            ViewModel.StartDate = new DateTime(2013, 02, 01);
            ViewModel.EndDate = new DateTime(2013, 08, 01);
            //алешкин код
            ViewModel = ProcessesEngine.InitMainModel(ViewModel.StartDate, ViewModel.EndDate);
            ViewModel.LiveStreamModel = ProcessesEngine.GetLiveStream(ViewModel.StartDate, ViewModel.EndDate);

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

            // Бизнес Анализ
            ViewModel.GeneralBA = ProcessesEngine.GetGeneralBusinessAnalysis(ViewModel.StartDate, ViewModel.EndDate, ViewModel);
            ViewModel.ProfitBA = ProcessesEngine.GetProfitBA(ViewModel);
            ViewModel.SalesBA = ProcessesEngine.GetSalesBA(ViewModel);
            ViewModel.CostsBA = ProcessesEngine.GetCostsBA(ViewModel);
            ViewModel.PurchaseBA = ProcessesEngine.GetPurchaseBA(ViewModel);
            ViewModel.WorkingСapitalBA = ProcessesEngine.GetWorkingСapitalBA(ViewModel);

            // Стресс-тестирование


            // Биндинг
            BusinessAnalysisControl.DataBind(ViewModel);

            ResBusinessControl.DataBind(ViewModel);
        }
    }
}
