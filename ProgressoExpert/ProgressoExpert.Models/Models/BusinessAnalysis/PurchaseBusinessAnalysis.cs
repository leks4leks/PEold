using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class PurchaseBusinessAnalysis : BaseViewModel
    {        
        /// <summary>
        /// закуп
        /// </summary>
        public decimal allPurchase
        {
            get { return _allPurchase; }
            set { SetValue(ref _allPurchase, value, "allPurchase"); }
        }
        private decimal _allPurchase = 0;

        /// <summary>
        /// разница с пред периодом
        /// </summary>
        public string difPastPeriod
        {
            get { return _difPastPeriod; }
            set { SetValue(ref _difPastPeriod, value, "difPastPeriod"); }
        }
        private string _difPastPeriod;

        /// <summary>
        /// макс закупки за период
        /// </summary>
        public decimal maxPurchaseByMonth
        {
            get { return _maxPurchaseByMonth; }
            set { SetValue(ref _maxPurchaseByMonth, value, "maxPurchaseByMonth"); }
        }
        private decimal _maxPurchaseByMonth;

        /// <summary>
        /// средние заупки
        /// </summary>
        public decimal averagePurchaseByMonth
        {
            get { return _averagePurchaseByMonth; }
            set { SetValue(ref _averagePurchaseByMonth, value, "averagePurchaseByMonth"); }
        }
        private decimal _averagePurchaseByMonth;
                        
        /// <summary>
        /// закуп по видам товаров
        /// </summary>
        public Dictionary<string, decimal> PurchaseByGoodsDiagram
        {
            get { return _PurchaseByGoodsDiagram; }
            set { SetValue(ref _PurchaseByGoodsDiagram, value, "PurchaseByGoodsDiagram"); }
        }
        private Dictionary<string, decimal> _PurchaseByGoodsDiagram;
        
        /// <summary>
        /// продажи по видам товаров
        /// </summary>
        public Dictionary<string, decimal> salesByGoodsDiagram
        {
            get { return _salesByGoodsDiagram; }
            set { SetValue(ref _salesByGoodsDiagram, value, "salesByGoodsDiagram"); }
        }
        private Dictionary<string, decimal> _salesByGoodsDiagram;

        /// <summary>
        /// закуп по поставщикам
        /// </summary>
        public Dictionary<string, decimal> PurchaseByClientDiagram
        {
            get { return _PurchaseByClientDiagram; }
            set { SetValue(ref _PurchaseByClientDiagram, value, "PurchaseByClientDiagram"); }
        }
        private Dictionary<string, decimal> _PurchaseByClientDiagram;

        /// <summary>
        /// оплата по поставщикам
        /// </summary>
        public Dictionary<string, decimal> PaymentByClientDiagram
        {
            get { return _PaymentByClientDiagram; }
            set { SetValue(ref _PaymentByClientDiagram, value, "PaymentByClientDiagram"); }
        }
        private Dictionary<string, decimal> _PaymentByClientDiagram;
        
        /// <summary>
        /// Доли по поставщикам
        /// </summary>
        public Dictionary<string, decimal> ClientDiagramInfo
        {
            get { return _ClientDiagramInfo; }
            set { SetValue(ref _ClientDiagramInfo, value, "ClientDiagramInfo"); }
        }
        private Dictionary<string, decimal> _ClientDiagramInfo;

        /// <summary>
        /// оплата - закуп к оплате и продажи
        /// </summary>
        public Dictionary<string, decimal> PaymentDiagram 
        {
            get { return _PaymentDiagram; }
            set { SetValue(ref _PaymentDiagram, value, "PaymentDiagram"); }
        }
        private Dictionary<string, decimal> _PaymentDiagram;
        
        /// <summary>
        /// закуп - закуп к оплате и продажи
        /// </summary>
        public Dictionary<string, decimal> PurchaseDiagram
        {
            get { return _PurchaseDiagram; }
            set { SetValue(ref _PurchaseDiagram, value, "PurchaseDiagram"); }
        }
        private Dictionary<string, decimal> _PurchaseDiagram;

        /// <summary>
        /// продажи - закуп к оплате и продажи
        /// </summary>
        public Dictionary<string, decimal> SalesDiagram
        {
            get { return _SalesDiagram; }
            set { SetValue(ref _SalesDiagram, value, "SalesDiagram"); }
        }
        private Dictionary<string, decimal> _SalesDiagram;

        /// <summary>
        /// продажи вс Закупки
        /// </summary>
        public decimal SalesvsPurchase
        {
            get { return _SalesvsPurchase; }
            set { SetValue(ref _SalesvsPurchase, value, "SalesvsPurchase"); }
        }
        private decimal _SalesvsPurchase = 0;

        /// <summary>
        /// продажи вс Закупки разница с прошлым периодом
        /// </summary>
        public decimal difSalesvsPurchasePastPeriod
        {
            get { return _difSalesvsPurchasePastPeriod; }
            set { SetValue(ref _difSalesvsPurchasePastPeriod, value, "difSalesvsPurchasePastPeriod"); }
        }
        private decimal _difSalesvsPurchasePastPeriod = 0;


        /// <summary>
        /// оплата вс Закупки
        /// </summary>
        public decimal PaymentvsPurchase
        {
            get { return _PaymentvsPurchase; }
            set { SetValue(ref _PaymentvsPurchase, value, "PaymentvsPurchase"); }
        }
        private decimal _PaymentvsPurchase = 0;

        /// <summary>
        /// оплата вс Закупки разница с прошлым периодом
        /// </summary>
        public decimal difPaymentvsPurchasePastPeriod
        {
            get { return _difPaymentvsPurchasePastPeriod; }
            set { SetValue(ref _difPaymentvsPurchasePastPeriod, value, "difPaymentvsPurchasePastPeriod"); }
        }
        private decimal _difPaymentvsPurchasePastPeriod = 0;
    }
}
