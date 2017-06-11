using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class Cuenta
    {
        public int CuentaId{ set; get; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int NumeroCuenta { set; get; }
        public int pin { set; get; }
        public string saldo { set; get; }
       
        public BaseDatos BaseDatos { set; get; }


        //Retiro
        public List<Retiro> Retiros { get; set; }

        public Cuenta()
        {
            Retiros = new List<Retiro>();
        }


    }
}
