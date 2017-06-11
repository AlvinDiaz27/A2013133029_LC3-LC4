using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class Retiro
    {
        public int RetiroId { set; get; }
        public string Monto { set; get; }

        //     public int idATM { set; get; }
        public Atm Atm { set; get; }

        //     public int idTeclado { set; get; }
        public Teclado Teclado { set; get; }

        //     public int idPantalla { set; get; }
        public Pantalla Pantalla { set; get; }

        public BaseDatos BaseDatos { get; set; }

        //    public int idDispensadorEfectivo { set; get; }
        public DispensadorEfectivo Dispensadorefectivo { set; get; }

        //Cuenta
        public ICollection<Cuenta> Cuentas { get; set; }
        public Retiro()
        {
            Cuentas = new HashSet<Cuenta>();
        }


    }
}
