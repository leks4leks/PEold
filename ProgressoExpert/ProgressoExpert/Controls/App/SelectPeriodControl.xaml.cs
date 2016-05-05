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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.App
{
    /// <summary>
    /// Логика взаимодействия для SelectPeriodControl.xaml
    /// </summary>
    public partial class SelectPeriodControl : UserControl
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public SelectPeriodControl()
        {
            InitializeComponent();
        }

        public SelectPeriodControl(MainModel model)
        {
            InitializeComponent();

            StartDate = model.StartDate;
            EndDate = model.EndDate;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }

        private void MonthSelect(object sender, RoutedEventArgs e)
        {
            ChecToggleButton(sender as ToggleButton);
        }

        private void QuarterSelect(object sender, RoutedEventArgs e)
        {
            ChecToggleButton(sender as ToggleButton);
        }

        private void ChecToggleButton(ToggleButton selectedBtn)
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
    }
}
