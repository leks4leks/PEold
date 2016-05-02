using ProgressoExpert.Controls.Utils;
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

namespace ProgressoExpert.Controls.Data.BusinessAnalysis.Common
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisTop.xaml
    /// </summary>
    public partial class BusinessAnalysisTop : UserControl
    {
        GeneralBusinessAnalysis ViewModel;
        public BusinessAnalysisTop()
        {
            InitializeComponent();
        }

        public void DataBind(GeneralBusinessAnalysis model)
        {
            ViewModel = (GeneralBusinessAnalysis)model;
            this.DataContext = (GeneralBusinessAnalysis)model;
            CurrentAssetsTb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureCompanyDiagram["Оборотные активы"].ToString());
            LongTermAssetsTb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureCompanyDiagram["Долгосрочные активы"].ToString());
            CurrentDebtTb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureCompanyDiagram["Текущая задолженность"].ToString());
            LongTermDebtTb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureCompanyDiagram["Долгосрочная задолженность"].ToString());
            EquityTb.Text = string.Format(FormatUtils.Percentage, ViewModel.StructureCompanyDiagram["Собственный капитал"].ToString());
            UpdateColors();
        }

        private void UpdateColors()
        {
            SalesAnFirstTb.Style = ViewModel.SalesAnFirst >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            SalesAnSecondTb.Style = ViewModel.SalesAnSecond >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            CostPriceAnFirstTb.Style = ViewModel.CostPriceAnFirst >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            CostPriceAnSecondTb.Style = ViewModel.CostPriceAnSecond >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            GrossProfitAnFirstTb.Style = ViewModel.GrossProfitAnFirst >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            GrossProfitAnSecondTb.Style = ViewModel.GrossProfitAnSecond >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            CostAnFirstTb.Style = ViewModel.CostAnFirst >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            CostAnSecondTb.Style = ViewModel.CostAnSecond >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            NetProfitAnFirstTb.Style = ViewModel.NetProfitAnFirst >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");

            NetProfitAnSecondTb.Style = ViewModel.NetProfitAnSecond >= 0
                ? (Style)FindResource("TextBlock18BoldGreen0CenterCenter")
                : (Style)FindResource("TextBlock18RBolded3CenterCenter");
        }
    }
}
