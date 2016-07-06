using ProgressoExpert.Controls.Utils;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressoExpert.Controls.Data
{
    /// <summary>
    /// Логика взаимодействия для StressTestingControl.xaml
    /// </summary>
    public partial class StressTestingControl : UserControl
    {
        StressTestingModel ViewModel;

        public StressTestingControl()
        {
            InitializeComponent();
        }

        public void DataBind(StressTestingModel model)
        {
            ViewModel = model;
            //DataContext = model;
            StressTestingGeneralControl.DataBind(ViewModel);
        }
    }
}
