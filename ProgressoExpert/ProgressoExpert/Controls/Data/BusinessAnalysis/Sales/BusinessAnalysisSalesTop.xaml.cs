using ProgressoExpert.Models.Models.BusinessAnalysis;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Sales
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisSalesTop.xaml
    /// </summary>
    public partial class BusinessAnalysisSalesTop : UserControl
    {
        SalesBusinessAnalysis ViewModel;

        public BusinessAnalysisSalesTop()
        {
            InitializeComponent();
        }

        public void DataBind(SalesBusinessAnalysis model)
        {
            ViewModel = (SalesBusinessAnalysis)model;
            this.DataContext = (SalesBusinessAnalysis)model;
            UpdateColors();
        }

        private void UpdateColors()
        {
            AveragePercentSaleGoodsTb.Style = ViewModel.DifPercentSaleGoods >= 0
                ? (Style)FindResource("TextBlockStyle19BoldGreen4Bottom")
                : (Style)FindResource("TextBlockStyle19BoldRed3Bottom");

            AveragePercentPaymentBuyerTb.Style = ViewModel.DifPercentPaymentBuyer >= 0
                ? (Style)FindResource("TextBlockStyle19BoldGreen4Bottom")
                : (Style)FindResource("TextBlockStyle19BoldRed3Bottom");
        }
    }
}
