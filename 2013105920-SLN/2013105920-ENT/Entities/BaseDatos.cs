using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.Entities
{
    public class BaseDatos
    {
        public int BaseDatosId { set; get; }
        public bool AutentificarCuenta { get; set; }
        public decimal ObtenerSaldoDisponible { get; set; }
        public decimal ObtenerSaldoTotal { get; set; }
        public decimal Debitar { get; set; }
        public decimal Acreditar { get; set; }

        public String Administrador { set; get; }
        public List<Cuenta> ListaCuentas { set; get; }

        public int idATM { set; get; }
        public Atm Atm { set; get; }
        public Retiro Retiro { get; set; }

        public BaseDatos()
        {
            ListaCuentas = new List<Cuenta>();
        }

    }
}
