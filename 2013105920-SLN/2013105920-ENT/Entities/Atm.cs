using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class Atm
    {
        public int AtmId { set; get; }

        public string Mensaje { get; set; }
        public RanuraDeposito ranuradeposito { set; get; }
       public int idRanuraDeposito { set; get; }

        public Teclado teclado { set; get; }
       public int idTeclado { set; get; }

        public DispensadorEfectivo dispensadorEfectivo { set; get; }
        public int idDispensadorEfectivo { set; get; }

        public Pantalla pantalla { set; get; }
       public int idPantalla { set; get; }

        public int idRetiro { set; get; }
        public Retiro Retiro { set; get; }

        public BaseDatos BaseDatos { set; get; }
        public int idBaseDatos { set; get; }


    }
}
