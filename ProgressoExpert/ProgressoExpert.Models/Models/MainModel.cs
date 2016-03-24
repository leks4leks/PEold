﻿using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models.BaseVM;
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
        #region Common
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

        public InfoModel InfoModel = new InfoModel();

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



    }
}
