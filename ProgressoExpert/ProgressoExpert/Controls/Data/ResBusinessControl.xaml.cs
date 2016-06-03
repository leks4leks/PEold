using ProgressoExpert.Models.Models;
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
    /// Логика взаимодействия для ResBusinessControl.xaml
    /// </summary>
    public partial class ResBusinessControl : UserControl
    {
        public ResBusinessControl()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel vm)
        {
            RB_Balance.DataBind(vm);
            RB_ProfitLossReport.DataBind(vm);
            RB_StatementCashFlows.DataBind(vm);
        }
    }
}
