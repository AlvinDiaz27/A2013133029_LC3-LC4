using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class RanuraDeposito
    {
        public int RanuraDepositoId { set; get; }
        public int Cantidad { get; set; }

        public int AtmId { set; get; }
        public Atm Atm { set; get; }

    }
}
