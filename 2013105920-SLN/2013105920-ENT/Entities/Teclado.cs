using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class Teclado
    {
        public int TecladoId { set; get; }
        

        public int idATM { set; get; }
        public Atm Atm { set; get; }

        public int idRetiro { set; get; }
        public Retiro Retiro { set; get; }

    }
}
