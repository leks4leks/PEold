using ProgressoExpert.Common.Enums;
using ProgressoExpert.Models.Entities;
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
        public static List<TranzEnt> GetAllTrans(DateTime stDate, DateTime? endDate)
        {
            List<TranzEnt> res = new List<TranzEnt>();
            using (base3Entities db = new base3Entities())
            {
                if (endDate == null)
                {
                    res = (from acctr in db.C_AccRg420
                           join accCr in db.C_Acc18 on acctr.C_AccountCtRRef equals accCr.C_IDRRef
                              join accDt in db.C_Acc18 on acctr.C_AccountDtRRef equals accDt.C_IDRRef
                              where acctr.C_Period < stDate
                              select new TranzEnt
                              {
                                  Money = acctr.C_Fld424,
                                  period = acctr.C_Period,
                                  ScoreCt = accCr.C_Code,
                                  ScoreDt = accDt.C_Code
                              }).AsParallel().ToList();
                }
                if (endDate != null)
                {
                    res = (
                           from accRg in db.C_AccRg420 // Выгрузим все транзакции на период который мы указали
                           join accDt in db.C_Acc18 on accRg.C_AccountDtRRef equals accDt.C_IDRRef
                           join accCt in db.C_Acc18 on accRg.C_AccountCtRRef equals accCt.C_IDRRef
                           where accRg.C_Period >= stDate && accRg.C_Period < endDate
                           select new TranzEnt
                           {
                               Money = accRg.C_Fld424,
                               period = accRg.C_Period,
                               ScoreDt = accDt.C_Code,
                               ScoreCt = accCt.C_Code
                           }).AsParallel().ToList();             
                }

                return res;
            }
        }

        /// <summary>
        /// официалки Взять все транзакции(Если endDate == null - на начало периода. Если endDate != null - на конец периода)
        /// </summary>
        /// <param name="stDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<TranzEnt> GetAllTransOriginal(DateTime stDate, DateTime? endDate)
        {
            List<string> tmp = new List<string>();

            List<TranzEnt> res = new List<TranzEnt>();
            using (base3Entities db = new base3Entities())
            {
                if (endDate == null)
                {
                    res = (from acctr in db.C_AccRg420
                           join accCr in db.C_Acc17 on acctr.C_AccountCtRRef equals accCr.C_IDRRef
                           join accDt in db.C_Acc17 on acctr.C_AccountDtRRef equals accDt.C_IDRRef
                           where acctr.C_Period < stDate
                           select new TranzEnt
                           {
                               Money = acctr.C_Fld424,
                               period = acctr.C_Period,
                               ScoreCt = accCr.C_Code,
                               ScoreDt = accDt.C_Code
                           }).ToList();
                }
                if (endDate != null)
                {
                    res = (
                           from accRg in db.C_AccRg420 // Выгрузим все транзакции на период который мы указали
                           join accDt in db.C_Acc17 on accRg.C_AccountDtRRef equals accDt.C_IDRRef
                           join accCt in db.C_Acc17 on accRg.C_AccountCtRRef equals accCt.C_IDRRef
                           where accRg.C_Period >= stDate &&
                           (tmp.Contains(accCt.C_Code) ||
                           tmp.Contains(accDt.C_Code))
                           select new TranzEnt
                           {
                               Money = accRg.C_Fld424,
                               period = accRg.C_Period,
                               ScoreDt = accDt.C_Code,
                               ScoreCt = accCt.C_Code
                           }).ToList();
                }

                return res;
            }
        }

        public static List<RefGroupsEnt> GetAllGroups()
        {
            using (base2Entities db = new base2Entities())
            {
                return (from cref in db.C_Reference91 // выгрузим все, чтобы 1000 раз не лезть в БД
                        select new RefGroupsEnt
                        {
                            Name = cref.C_Description,
                            Code = cref.C_Code
                        }).ToList();
            }
        }

        public static int GetTimeSpan()
        {
            using (base3Entities db = new base3Entities())
            {
                return db.C_YearOffset.First().Offset;
            }
        }
    }


}
