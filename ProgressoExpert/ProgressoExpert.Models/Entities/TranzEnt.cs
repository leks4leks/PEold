using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.DataAccess.Entities
{
    public class TranzEnt
    {
        public byte[] CtRRef;
        public byte[] DtRRef;
        public decimal Money;
        public decimal? MoneyDb;
        public decimal? MoneyCr;

        public decimal? MoneyDb2;
        public decimal? MoneyCr2;
        public DateTime period;
    }
}
