using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Common.Enums
{
    public enum ScoresForBusinessResults : int
    {
        #region Активы - Сумма графы "Краткосрочные активы" и "Долгосрочные активы" является показателем графы "Итого активов"
        #region Сумма статей с 1 по 9 является показателем графы "Краткосрочные активы"
        /// <summary>
        /// 1. Денежные средства в кассе  - 1010
        /// </summary>
        CashInCashBox1 = 1010,

        /// <summary>
        /// 1. Денежные средства в кассе  - 1020
        /// </summary>
        CashInCashBox2 = 1020,

        /// <summary>
        /// 2. Денежные средства на рассчетном счете - 1030
        /// </summary>
        CasnInCheckingAccount1 = 1030,

        /// <summary>
        /// 2. Денежные средства на рассчетном счете - 1040
        /// </summary>
        CasnInCheckingAccount2 = 1040,

        /// <summary>
        /// 3. Депозиты - 1050
        /// </summary>
        Deposits = 1050,

        /// <summary>
        /// 4. Дебиторская задолженность - 1210
        /// </summary>        
        Receivables = 1210,

        /// <summary>
        /// 5. Сырье и материалы - 1310
        /// </summary>
        RawAndMaterials = 1310,

        /// <summary>
        /// 6. Товары - 1320
        /// </summary>
        Goods1 = 1320,

        /// <summary>
        /// 6. Товары - 1330
        /// </summary>
        Goods2 = 1330,

        /// <summary>
        /// 7. Незавершенное производство - 1340
        /// </summary>
        UnfinishedProduction = 1340,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1060
        /// </summary>        
        OtherCurrentAssets1 = 1060,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1100
        /// </summary>        
        OtherCurrentAssets2 = 1100,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1230
        /// </summary>        
        OtherCurrentAssets3 = 1230,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1250
        /// </summary>        
        OtherCurrentAssets4 = 1250,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1260
        /// </summary>        
        OtherCurrentAssets5 = 1260,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1270
        /// </summary>        
        OtherCurrentAssets6 = 1270,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1280
        /// </summary>        
        OtherCurrentAssets7 = 1280,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1290
        /// </summary>        
        OtherCurrentAssets8 = 1290,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1350
        /// </summary>        
        OtherCurrentAssets9 = 1350,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1360
        /// </summary>        
        OtherCurrentAssets10 = 1360,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1500
        /// </summary>        
        OtherCurrentAssets11 = 1500,

        /// <summary>
        /// 8. Прочие краткосрочные активы - 1600
        /// </summary>        
        OtherCurrentAssets12 = 1600,

        /// <summary>
        /// 9. Налоговые активы - 1400
        /// </summary>
        TaxAssets = 1400,
        #endregion

        #region Сумма статей с 10 по 15 является показателем графы "Долгосрочные активы"
        /// <summary>
        /// 10. Долгосрочная Дебиторская задолженность - 2110
        /// </summary>        
        LongTermReceivables = 2110,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2010
        /// </summary>        
        OtherLongTermReceivables1 = 2010,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2020
        /// </summary>        
        OtherLongTermReceivables2 = 2020,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2030
        /// </summary>        
        OtherLongTermReceivables3 = 2030,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2040
        /// </summary>        
        OtherLongTermReceivables4 = 2040,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2130
        /// </summary>        
        OtherLongTermReceivables5 = 2130,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2150
        /// </summary>        
        OtherLongTermReceivables6 = 2150,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2160
        /// </summary>        
        OtherLongTermReceivables7 = 2160,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2170
        /// </summary>        
        OtherLongTermReceivables8 = 2170,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2180
        /// </summary>        
        OtherLongTermReceivables9 = 2180,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2910
        /// </summary>        
        OtherLongTermReceivables10 = 2910,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2920
        /// </summary>        
        OtherLongTermReceivables11 = 2920,

        /// <summary>
        /// 11. Прочая долгосрочная Дебиторская задолжность - 2940
        /// </summary>        
        OtherLongTermReceivables12 = 2940,

        /// <summary>
        /// 12. Инвестиции - 2200
        /// </summary>   
        Investments1 = 2200,

        /// <summary>
        /// 12. Инвестиции - 2300
        /// </summary>   
        Investments2 = 2300,

        /// <summary>
        /// 12. Инвестиции - 2930
        /// </summary>   
        Investments3 = 2930,

        /// <summary>
        /// 13. Основные средства - 2400
        /// </summary>        
        FixedAssets = 2400,

        /// <summary>
        /// 14. Нематериальные активы - 2700
        /// </summary>
        IntangibleAssets = 2700,

        /// <summary>
        /// 15. Долгосрочные налоговые активы
        /// </summary>
        LongTermTaxAssets = 2800,
        #endregion
        #endregion

        #region Пассивы - Сумма графы "Итого краткосрочная задолженность", "Итого долгосрочная задолженность", "Собственный капитал" является показателем графы "Итого Валюта Баланса" (в правой стороне Баланса)
        #region Сумма статей с 16 по 22 является показателем графы "Краткосрочные долги"
        /// <summary>
        /// 16. Краткосрочные банковские займы - 3010
        /// </summary>        
        ShortTermBankLoans1 = 3010,

        /// <summary>
        /// 16. Краткосрочные банковские займы - 3020
        /// </summary>        
        ShortTermBankLoans2 = 3020,

        /// <summary>
        /// 17. Задолженность по КПН/ИПН - 3110
        /// </summary>        
        DebtCitIit = 3110,

        /// <summary>
        /// 18. Задолженность по НДС - 3130
        /// </summary>        
        DebtVat = 3130,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3120
        /// </summary>   
        OtherTaxesPayable1 = 3120,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3150
        /// </summary>   
        OtherTaxesPayable2 = 3150,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3160
        /// </summary>   
        OtherTaxesPayable3 = 3160,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3170
        /// </summary>   
        OtherTaxesPayable4 = 3170,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3180
        /// </summary>   
        OtherTaxesPayable5 = 3180,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3190
        /// </summary>   
        OtherTaxesPayable6 = 3190,

        /// <summary>
        /// 19. Прочая задолженность по налогам - 3200
        /// </summary>   
        OtherTaxesPayable7 = 3200,

        /// <summary>
        /// 20. Задолженность перед контрагентами - 3310
        /// </summary>
        PayablesToCounterpartiesShortTermDebts = 3310,

        /// <summary>
        /// 21. Задолженность перед сотрудниками - 3350
        /// </summary>           
        PayablesToEmployees = 3350,

        /// <summary>
        /// 22. Прочая задолженность   - 3030
        /// </summary>        
        OtherDebtsShortTermDebts1 = 3030,

        /// <summary>
        /// 22. Прочая задолженность   - 3040
        /// </summary>        
        OtherDebtsShortTermDebts2 = 3040,

        /// <summary>
        /// 22. Прочая задолженность   - 3050
        /// </summary>        
        OtherDebtsShortTermDebts3 = 3050,

        /// <summary>
        /// 22. Прочая задолженность   - 3330
        /// </summary>        
        OtherDebtsShortTermDebts4 = 3330,

        /// <summary>
        /// 22. Прочая задолженность   - 3360
        /// </summary>        
        OtherDebtsShortTermDebts5 = 3360,

        /// <summary>
        /// 22. Прочая задолженность   - 3370
        /// </summary>        
        OtherDebtsShortTermDebts6 = 3370,

        /// <summary>
        /// 22. Прочая задолженность   - 3380
        /// </summary>        
        OtherDebtsShortTermDebts7 = 3380,

        /// <summary>
        /// 22. Прочая задолженность   - 3390
        /// </summary>        
        OtherDebtsShortTermDebts8 = 3390,

        /// <summary>
        /// 22. Прочая задолженность   - 3400
        /// </summary>        
        OtherDebtsShortTermDebts9 = 3400,

        /// <summary>
        /// 22. Прочая задолженность   - 3500
        /// </summary>        
        OtherDebtsShortTermDebts10 = 3500,
        #endregion

        #region Сумма статей с 23 по 26 является показателем графы "Долгосрочные долги"
        /// <summary>
        /// 23. Долгосрочные банковские займы - 4010
        /// </summary>   
        LongTermBankLoans1 = 4010,

        /// <summary>
        /// 23. Долгосрочные банковские займы - 4020
        /// </summary>   
        LongTermBankLoans2 = 4020,

        /// <summary>
        /// 24. Задолженность перед контрагентами - 4110
        /// </summary>  
        PayablesToCounterpartiesLongTermDebts = 4110,

        /// <summary>
        /// 25. Отложеннные налоговая задолженность - 4310
        /// </summary>
        DefferedTaxDebts = 4310,

        /// <summary>
        /// 26. Прочая задолженность - 4030
        /// </summary>        
        OtherDebtsLongTermDebts1 = 4030,

        /// <summary>
        /// 26. Прочая задолженность - 4100
        /// </summary>        
        OtherDebtsLongTermDebts2 = 4100,

        /// <summary>
        /// 26. Прочая задолженность - 4200
        /// </summary>        
        OtherDebtsLongTermDebts3 = 4200,

        /// <summary>
        /// 26. Прочая задолженность - 4400
        /// </summary>        
        OtherDebtsLongTermDebts4 = 4400,
        #endregion

        #region Сумма статей с 27 по 29 является показателем графы "Собственный капитал"
        /// <summary>
        /// 27. Уставной капитал - 5000
        /// </summary>        
        AuthorizedCapital1 = 5000,

        /// <summary>
        /// 27. Уставной капитал - 5100
        /// </summary>        
        AuthorizedCapital2 = 5100,

        /// <summary>
        /// 28. Накопленная прибыль/убыток - 5500
        /// </summary>        
        AccumulatedProfitAndLoss = 5500,

        /// <summary>
        /// 29. Прочий капитал - 5100
        /// </summary>        
        OtherCapital = 5100,
        #endregion
        #endregion
    }
}									
										