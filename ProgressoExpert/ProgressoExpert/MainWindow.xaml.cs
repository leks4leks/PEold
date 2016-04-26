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
            ViewModel.LiveStreamModel = ProcessesEngine.GetLiveStream(ViewModel.StartDate, ViewModel.EndDate);
            LiveStreamControl.DataBind(ViewModel.LiveStreamModel);
        }
    }
}
