using ProgressoExpert.Models.Models;
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
using System.Windows.Shapes;

namespace ProgressoExpert
{
    /// <summary>
    /// Логика взаимодействия для SelectPeriod.xaml
    /// </summary>
    public partial class SelectPeriod : Window
    {
        private bool IsStartDateSelect = true;
        MainModel ViewModel;
        MainWindow MainWindow;

        public SelectPeriod()
        {
            InitializeComponent();
        }

        public SelectPeriod(MainModel model, MainWindow mainWindow)
        {
            InitializeComponent();
            ViewModel = (MainModel)model;
            ViewModel.StartDateTemp = ViewModel.StartDate;
            ViewModel.EndDateTemp = ViewModel.EndDate;
            DataContext = (MainModel)model;
            DateStartTb_MouseDown(this, null);
            MainWindow = mainWindow;
        }

        private void ChangePeriodBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.StartDate = ViewModel.StartDateTemp;
            ViewModel.EndDate = ViewModel.EndDateTemp;
            MainWindow.UpdateData();
            CancelBtn_Click(this, null);
        }


        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.StartDateTemp = ViewModel.StartDate;
            ViewModel.EndDateTemp = ViewModel.EndDate;
            if (IsStartDateSelect)
            {
                DateStartTb_MouseDown(this, null);
            }
            else
            {
                DateEndTb_MouseDown(this, null);
            }
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Кнопки Месяцы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonthSelect(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = sender as ToggleButton;
            if (btn.Name == "Month1Btn")
            {
                ChangeMonth(1);
            }
            else if (btn.Name == "Month2Btn")
            {
                ChangeMonth(2);
            }
            else if (btn.Name == "Month3Btn")
            {
                ChangeMonth(3);
            }
            else if (btn.Name == "Month4Btn")
            {
                ChangeMonth(4);
            }
            else if (btn.Name == "Month5Btn")
            {
                ChangeMonth(5);
            }
            else if (btn.Name == "Month6Btn")
            {
                ChangeMonth(6);
            }
            else if (btn.Name == "Month7Btn")
            {
                ChangeMonth(7);
            }
            else if (btn.Name == "Month8Btn")
            {
                ChangeMonth(8);
            }
            else if (btn.Name == "Month9Btn")
            {
                ChangeMonth(9);
            }
            else if (btn.Name == "Month10Btn")
            {
                ChangeMonth(10);
            }
            else if (btn.Name == "Month11Btn")
            {
                ChangeMonth(11);
            }
            else if (btn.Name == "Month12Btn")
            {
                ChangeMonth(12);
            }
            CheckToggleButton(sender as ToggleButton);
        }

        /// <summary>
        /// Кнопки Кварталы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuarterSelect(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = sender as ToggleButton;
            if (btn.Name == "Quarter1Btn")
            {
                ChangeMonth(1);
            }
            else if (btn.Name == "Quarter2Btn")
            {
                ChangeMonth(4);
            }
            else if (btn.Name == "Quarter3Btn")
            {
                ChangeMonth(7);
            }
            else if (btn.Name == "Quarter4Btn")
            {
                ChangeMonth(10);
            }
            CheckToggleButton(btn);
        }

        /// <summary>
        /// Поменять месяц
        /// </summary>
        /// <param name="month"></param>
        private void ChangeMonth(int month)
        {
            if (IsStartDateSelect)
            {
                ViewModel.StartDateTemp = new DateTime(ViewModel.StartDateTemp.Year, month, 1);
            }
            else
            {
                ViewModel.EndDateTemp = new DateTime(ViewModel.EndDateTemp.Year, month, 1);
            }
        }

        /// <summary>
        /// Поменять год
        /// </summary>
        /// <param name="year"></param>
        private void ChangeYear(int year)
        {
            if (IsStartDateSelect)
            {
                ViewModel.StartDateTemp = new DateTime(year, ViewModel.StartDateTemp.Month, 1);
            }
            else
            {
                ViewModel.EndDateTemp = new DateTime(year, ViewModel.EndDateTemp.Month, 1);
            }
        }

        /// <summary>
        /// Дата начала периода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateStartTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DateStartTb.BorderBrush = Brushes.Blue;
            DateEndTb.BorderBrush = Brushes.Black;
            IsStartDateSelect = true;
            Configure(ViewModel.StartDateTemp.Month, ViewModel.StartDateTemp.Year);
        }

        /// <summary>
        /// Дата конца периода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateEndTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DateStartTb.BorderBrush = Brushes.Black;
            DateEndTb.BorderBrush = Brushes.Blue;
            IsStartDateSelect = false;
            Configure(ViewModel.EndDateTemp.Month, ViewModel.EndDateTemp.Year);
        }


        /// <summary>
        /// Конфигурация кнопок по выбранной дате
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        private void Configure(int month, int year)
        {
            switch (month)
            {
                case 1:
                    CheckToggleButton(Month1Btn);
                    break;
                case 2:
                    CheckToggleButton(Month2Btn);
                    break;
                case 3:
                    CheckToggleButton(Month3Btn);
                    break;
                case 4:
                    CheckToggleButton(Month4Btn);
                    break;
                case 5:
                    CheckToggleButton(Month5Btn);
                    break;
                case 6:
                    CheckToggleButton(Month6Btn);
                    break;
                case 7:
                    CheckToggleButton(Month7Btn);
                    break;
                case 8:
                    CheckToggleButton(Month8Btn);
                    break;
                case 9:
                    CheckToggleButton(Month9Btn);
                    break;
                case 10:
                    CheckToggleButton(Month10Btn);
                    break;
                case 11:
                    CheckToggleButton(Month11Btn);
                    break;
                case 12:
                    CheckToggleButton(Month12Btn);
                    break;
            }

            YearSlider.Value = year;
        }

        /// <summary>
        /// Выделить кнопку (Месяц/квартал)
        /// </summary>
        /// <param name="selectedBtn"></param>
        private void CheckToggleButton(ToggleButton selectedBtn)
        {
            CheckToggleBtnOnWrapPanel(this.Month1Wrap, selectedBtn);
            CheckToggleBtnOnWrapPanel(this.Month2Wrap, selectedBtn);
            CheckToggleBtnOnWrapPanel(this.QuarterWrap, selectedBtn);
        }

        private void CheckToggleBtnOnWrapPanel(WrapPanel panel, ToggleButton selectedBtn)
        {
            foreach (var item in panel.Children)
            {
                if (item.GetType() == typeof(ToggleButton))
                {
                    ToggleButton btn = item as ToggleButton;
                    if (btn.Name == selectedBtn.Name)
                    {
                        btn.IsChecked = true;
                    }
                    else
                    {
                        btn.IsChecked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Год
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YearSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ViewModel != null)
            {
                ChangeYear(Convert.ToInt32(YearSlider.Value));
            }
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Deactivated_1(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
