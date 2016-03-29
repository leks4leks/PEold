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
    /// Логика взаимодействия для LiveStreamControl.xaml
    /// </summary>
    public partial class LiveStreamControl : UserControl
    {
        LiveStreamModel ViewModel;

        public LiveStreamControl()
        {
            ViewModel = (LiveStreamModel)this.DataContext;
            InitializeComponent();
            LsCurrentMonthControl.DataContext = ViewModel;
            LsTodayControl.DataContext = ViewModel;
        }

        public void DataBind(LiveStreamModel model)
        {
            ViewModel = model;
            //DataContext = (LiveStreamModel)model;
            LsTodayControl.DataBind(model);
            LsCurrentMonthControl.DataBind(model);
        }
    }
}
