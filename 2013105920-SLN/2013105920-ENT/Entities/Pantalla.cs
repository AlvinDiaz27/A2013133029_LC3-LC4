using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class Pantalla
    {
        public int PantallaId { set; get; }

        public int AtmId { set; get; }
        public Atm Atm { set; get; }

        public int RetiroId { set; get; }
        public Retiro Retiro { set; get; }


    }
}
