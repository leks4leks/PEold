using ProgressoExpert.Common.Enums;
using ProgressoExpert.DataAccess.Entities;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.DataAccess
{
    public class MainAccessor
    {
        /// <summary>
        /// Взять все транзакции(Если endDate == null - на начало периода. Если endDate != null - на конец периода)
        /// </summary>
        /// <param name="stDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<TranzEnt> GetAllTrans(DateTime stDate, DateTime? endDate, int timeSpan)
        {
            List<TranzEnt> res = new List<TranzEnt>();
            using (dbEntities db = new dbEntities())
            {                
                if (endDate == null)
                {
                    stDate = ((DateTime)stDate).AddYears(timeSpan);

                    res = (from accRg in db.C_AccRg10893 // Выгрузим все транзакции на начало периода
                           where accRg.C_Period < stDate
                           select new TranzEnt
                           {
                               CtRRef = accRg.C_AccountCtRRef,
                               DtRRef = accRg.C_AccountDtRRef,
                               Money = accRg.C_Fld10896,
                               period = accRg.C_Period
                           }).ToList();
                }
                if (endDate != null)
                {
                    endDate = ((DateTime)endDate).AddYears(timeSpan);
                    stDate = ((DateTime)stDate).AddYears(timeSpan);

                    res = (
                           from accRg in db.C_AccRg10893 // Выгрузим все транзакции на период который мы указали
                           where accRg.C_Period >= stDate && accRg.C_Period < endDate
                           select new TranzEnt
                           {
                               CtRRef = accRg.C_AccountCtRRef,
                               DtRRef = accRg.C_AccountDtRRef,
                               Money = accRg.C_Fld10896,
                               period = accRg.C_Period
                           }).ToList();
                }
                return res;
            }         
        }

        public static List<ScoreEnt> GetAllScores()
        {
            using (dbEntities db = new dbEntities())
            {
                return (from scr in db.C_Acc10 // выгрузим все, чтобы 1000 раз не лезть в БД
                              select new ScoreEnt
                              {
                                  Code = scr.C_Code,
                                  Id = scr.C_IDRRef
                              }).ToList();
            }
        }

        public static int GetTimeSpan()
        {
            using (dbEntities db = new dbEntities())
            {
                return db.C_YearOffset.First().Offset;
            }
        }

    }

    
}
