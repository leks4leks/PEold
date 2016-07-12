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

namespace ProgressoExpert.Controls.Data.ResBusiness
{
    /// <summary>
    /// Логика взаимодействия для RB_Balance.xaml
    /// </summary>
    public partial class RB_Balance : UserControl
    {
        public RB_Balance()
        {
            InitializeComponent();
        }

        public void DataBind(MainModel vm)
        {
            vm.BusinessResults.StartDateView = new DateTime(vm.StartDate.Year - vm.TimeSpan, vm.StartDate.Month, vm.StartDate.Day);
            vm.BusinessResults.EndDateView = new DateTime(vm.EndDate.Year - vm.TimeSpan, vm.EndDate.Month, vm.EndDate.Day);
            DataContext = vm;
        }
    }
}


