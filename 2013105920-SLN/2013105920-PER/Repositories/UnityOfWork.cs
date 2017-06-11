using _2013105920_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_PER.Repositories
{

    public class UnityOfWork : IUnityOfWork
    {
        private readonly CajeroDbContext _Context;
        //     private static UnityOfWork _Instance;
        //     private static readonly object _Lock = new object();

        public IAtmRepository ATMs { get; private set; }
        public IBaseDatosRepository BaseDatos { get; private set; }
        public ICuentaRepository Cuentas { get; private set; }
        public IPantallaRepository Pantallas { get; private set; }
        public IRanuraDepositoRepository RanuraDepositos { get; private set; }
        public IRetiroRepository Retiros { get; private set; }
        public ITecladoRepository Teclados { get; private set; }
        public IDispensadorEfectivoRepository DispensadorEfectivos { get; private set; }



        public UnityOfWork()
        {

            _Context = new CajeroDbContext();

            ATMs = new AtmRepository(_Context);
            BaseDatos = new BaseDatosRepository(_Context);
            Cuentas = new CuentaRepository(_Context);
            Pantallas = new PantallaRepository(_Context);
            DispensadorEfectivos = new DispensadorEfectivoRepository(_Context);
            RanuraDepositos = new RanuraDepositoRepository(_Context);
            Retiros = new RetiroRepository(_Context);
            Teclados = new TecladoRepository(_Context);
            


        }

        //Implementacion del patron Singleton para instanciar la clase UnityOfWork
        //Con este patron se asegura que en cualquier parte del codigo que se quiera
        //instanciar la BD, se devuelva la unica referencia.
        /*  public static UnityOfWork Instance
          {
              get
              {
                  //Variable de control para manejar el acceso concurrente
                  //al instanciamiento de las clases UnityOfWork
                  lock (_Lock)
                  {
                      if (_Instance == null)
                          _Instance = new UnityOfWork();
                  }

                  return _Instance;

              }


          }
          */

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }


        public void Dispose()
        {
            _Context.Dispose();

        }
        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.


        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }


    }
}
