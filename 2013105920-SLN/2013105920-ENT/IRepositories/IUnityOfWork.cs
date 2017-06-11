using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {

        IAtmRepository ATMs { get; }
        IBaseDatosRepository BaseDatos { get; }
        ICuentaRepository Cuentas { get; }
        IPantallaRepository Pantallas { get; }
        IRanuraDepositoRepository RanuraDepositos { get; }
        IRetiroRepository Retiros { get; }
        ITecladoRepository Teclados { get; }
        IDispensadorEfectivoRepository DispensadorEfectivos { get; }


        int SaveChanges();

        void StateModified(object entity);


    }
}
