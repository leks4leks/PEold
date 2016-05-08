using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models.App;
using ProgressoExpert.Models.Models.BaseVM;
using ProgressoExpert.Models.Models.BusinessAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class MainModel : BaseViewModel
    {
        #region Tranz

        public List<TranzEnt> StartTranz
        {
            get { return _startTranz; }
            set { SetValue(ref _startTranz, value, "StartTranz"); }
        }
        private List<TranzEnt> _startTranz;

        public List<TranzEnt> EndTranz
        {
            get { return _endTranz; }
            set { SetValue(ref _endTranz, value, "EndTranz"); }
        }
        private List<TranzEnt> _endTranz;

        public List<GroupsEnt> ADDSTranz
        {
            get { return _ADDSTranz; }
            set { SetValue(ref _ADDSTranz, value, "ADDSTranz"); }
        }
        private List<GroupsEnt> _ADDSTranz;

        public List<GroupsEnt> allADDSTranz
        {
            get { return _allADDSTranz; }
            set { SetValue(ref _allADDSTranz, value, "allADDSTranz"); }
        }
        private List<GroupsEnt> _allADDSTranz;

        public List<GroupsEnt> ADDSTranzPastPeriod
        {
            get { return _ADDSTranzPastPeriod; }
            set { SetValue(ref _ADDSTranzPastPeriod, value, "ADDSTranzPastPeriod"); }
        }
        private List<GroupsEnt> _ADDSTranzPastPeriod;

        public List<SalesModel> Sales
        {
            get { return _sales; }
            set { SetValue(ref _sales, value, "Sales"); }
        }
        private List<SalesModel> _sales;

        public List<RefGroupsEnt> RegGroups
        {
            get { return _regGroups; }
            set { SetValue(ref _regGroups, value, "RegGroups"); }
        }
        private List<RefGroupsEnt> _regGroups;

        public int TimeSpan
        {
            get { return _timeSpan; }
            set { SetValue(ref _timeSpan, value, "TimeSpan"); }
        }
        private int _timeSpan;

        #endregion

        #region Info & Visibility

        public InfoModel InfoModel;
        //public VisibilityModel VisibilityModel = new VisibilityModel();

        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetValue(ref _startDate, value, "StartDate"); }
        }
        private DateTime _startDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetValue(ref _endDate, value, "EndDate"); }
        }
        private DateTime _endDate;

        public DateTime StartDateTemp
        {
            get { return _startDateTemp; }
            set { SetValue(ref _startDateTemp, value, "StartDateTemp"); }
        }
        private DateTime _startDateTemp;

        public DateTime EndDateTemp
        {
            get { return _endDateTemp; }
            set { SetValue(ref _endDateTemp, value, "EndDateTemp"); }
        }
        private DateTime _endDateTemp;

        public DateTime newStTodayDate
        {
            get { return _newStTodayDate; }
            set { SetValue(ref _newStTodayDate, value, "newStTodayDate"); }
        }
        private DateTime _newStTodayDate;

        public DateTime newEndTodayDate
        {
            get { return _newEndTodayDate; }
            set { SetValue(ref _newEndTodayDate, value, "newEndTodayDate"); }
        }
        private DateTime _newEndTodayDate;

        #region Visibility

        /// <summary>
        /// Live Stream
        /// </summary>
        public bool LiveStreamVisibility
        {
            get { return _liveStreamVisibility; }
            set
            {
                if (value == true)
                {
                    SetInvisibleAll();
                }
                SetValue(ref _liveStreamVisibility, value, "LiveStreamVisibility");
            }
        }
        private bool _liveStreamVisibility = true;

        /// <summary>
        /// Анализ бизнеса
        /// </summary>
        public bool BusinessAnalysisVisibility
        {
            get { return _businessAnalysisVisibility; }
            set
            {
                if (value == true)
                {
                    SetInvisibleAll();
                }
                SetValue(ref _businessAnalysisVisibility, value, "BusinessAnalysisVisibility");
            }
        }
        private bool _businessAnalysisVisibility;

        /// <summary>
        /// Стресс-тестирование
        /// </summary>
        public bool StressTestingVisibility
        {
            get { return _stressTestingVisibility; }
            set
            {
                if (value == true)
                {
                    SetInvisibleAll();
                }
                SetValue(ref _stressTestingVisibility, value, "StressTestingVisibility");
            }
        }
        private bool _stressTestingVisibility;

        /// <summary>
        /// Результаты бизнеса
        /// </summary>
        public bool ResBusinessVisibility
        {
            get { return _resBusinessVisibility; }
            set
            {
                if (value == true)
                {
                    SetInvisibleAll();
                }
                SetValue(ref _resBusinessVisibility, value, "ResBusinessVisibility");
            }
        }
        private bool _resBusinessVisibility;

        /// <summary>
        /// Прогноз
        /// </summary>
        public bool ForecastVisibility
        {
            get { return _forecastVisibility; }
            set
            {
                if (value == true)
                {
                    SetInvisibleAll();
                }
                SetValue(ref _forecastVisibility, value, "ForecastVisibility");
            }
        }
        private bool _forecastVisibility;

        public void SetInvisibleAll()
        {
            LiveStreamVisibility = false;
            BusinessAnalysisVisibility = false;
            StressTestingVisibility = false;
            ResBusinessVisibility = false;
            ForecastVisibility = false;
        }

        #endregion

        #endregion

        public LiveStreamModel LiveStreamModel;

        /// <summary>
        /// Результаты бизнеса
        /// </summary>
        public BusinessResults BusinessResults
        {
            get { return _businessResults; }
            set { SetValue(ref _businessResults, value, "BusinessResults"); }
        }
        private BusinessResults _businessResults;

        /// <summary>
        /// Отчет о прибылях и убытках
        /// </summary>
        public ReportProfitAndLoss ReportProfitAndLoss
        {
            get { return _reportProfitAndLoss; }
            set { SetValue(ref _reportProfitAndLoss, value, "ReportProfitAndLoss"); }
        }
        private ReportProfitAndLoss _reportProfitAndLoss;        

        /// <summary>
        /// Коэффициенты и основные показатели
        /// </summary>
        public RatiosIndicatorsResult RatiosIndicatorsResult
        {
            get { return _ratiosIndicatorsResult; }
            set { SetValue(ref _ratiosIndicatorsResult, value, "RatiosIndicatorsResult"); }
        }
        private RatiosIndicatorsResult _ratiosIndicatorsResult;

        /// <summary>
        /// Основная вкладка Анализа бизнеса
        /// </summary>
        public GeneralBusinessAnalysis GeneralBA
        {
            get { return _generalBA; }
            set { SetValue(ref _generalBA, value, "GeneralBA"); }
        }
        private GeneralBusinessAnalysis _generalBA;
              

        /// <summary>
        /// прибыль Анализа бизнеса
        /// </summary>
        public ProfitBusinessAnalysis ProfitBA
        {
            get { return _profitBA; }
            set { SetValue(ref _profitBA, value, "ProfitBA"); }
        }
        private ProfitBusinessAnalysis _profitBA;

        /// <summary>
        /// продажи Анализа бизнеса
        /// </summary>
        public SalesBusinessAnalysis SalesBA
        {
            get { return _salesBA; }
            set { SetValue(ref _salesBA, value, "SalesBA"); }
        }
        private SalesBusinessAnalysis _salesBA;

        /// <summary>
        /// расходы Анализа бизнеса
        /// </summary>
        public CostsBusinessAnalysis CostsBA
        {
            get { return _costsBA; }
            set { SetValue(ref _costsBA, value, "CostsBA"); }
        }
        private CostsBusinessAnalysis _costsBA;

        /// <summary>
        /// закуп Анализа бизнеса
        /// </summary>
        public PurchaseBusinessAnalysis PurchaseBA
        {
            get { return _purchaseBA; }
            set { SetValue(ref _purchaseBA, value, "PurchaseBA"); }
        }
        private PurchaseBusinessAnalysis _purchaseBA;

        /// <summary>
        /// оборотный капитал Анализа бизнеса
        /// </summary>
        public WorkingСapitalBusinessAnalysis WorkingСapitalBA
        {
            get { return _workingСapitalBA; }
            set { SetValue(ref _workingСapitalBA, value, "WorkingСapitalBA"); }
        }
        private WorkingСapitalBusinessAnalysis _workingСapitalBA;

        /// <summary>
        /// Коэффициенты и основные показатели
        /// </summary>
        public bool Test
        {
            get { return _test; }
            set { SetValue(ref _test, value, "Test"); }
        }
        private bool _test;


        public MainModel()
        {
            InfoModel = new InfoModel();
            LiveStreamModel = new LiveStreamModel();
        }
    }
}
