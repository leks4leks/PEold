using ProgressoExpert.Models.Models;
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

namespace ProgressoExpert.Controls.Data
{
    /// <summary>
    /// Логика взаимодействия для BusinessAnalysisControl.xaml
    /// </summary>
    public partial class BusinessAnalysisControl : UserControl
    {
        MainModel ViewModel;
        public BusinessAnalysisControl()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel model)
        {
            ViewModel = model;
            
            // Общее
            BusinessAnalysisTop.DataBind(model.GeneralBA);
            BusinessAnalysisCommonBottom.DataBind(model);

            // Прибыль
            BusinessAnalysisProfitTop.DataBind(model.ProfitBA);
            BusinessAnalysisProfitBottom.DataBind(model.ProfitBA);

            // Продажи
            BusinessAnalysisSalesTop.DataBind(model.SalesBA);
            BusinessAnalysisSalesBottom.DataBind(model.SalesBA);

            // Расходы
            BusinessAnalysisExpensesLeft.DataBind(model.CostsBA);
            BusinessAnalysisExpensesRight.DataBind(model.CostsBA);

            // Закуп
            BusinessAnalysisPurchaseLeft.DataBind(model.PurchaseBA);
            BusinessAnalysisPurchaseRight.DataBind(model.PurchaseBA);

            // Оборотный капитал
            BusinessAnalysisWorkingCapitalLeft.DataBind(model.WorkingСapitalBA);
            BusinessAnalysisWorkingCapitalRight.DataBind(model.WorkingСapitalBA);
        }
    }
}
