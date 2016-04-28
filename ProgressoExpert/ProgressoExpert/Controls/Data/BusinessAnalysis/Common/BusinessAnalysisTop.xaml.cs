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
        }
    }
}
