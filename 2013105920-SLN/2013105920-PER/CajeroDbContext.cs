using _2013105920_ENT.Entities;
using _2013105920_PER.ConfigurationTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_PER
{
    public class CajeroDbContext : DbContext
    {
        public DbSet<Atm> Atm { get; set; }
        public DbSet<BaseDatos> BaseDatos { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<DispensadorEfectivo> DispensadorEfectivo { get; set; }
        public DbSet<Pantalla> Pantalla { get; set; }
        public DbSet<RanuraDeposito> RanuraDeposito { get; set; }
        public DbSet<Retiro> Retiro { get; set; }
        public DbSet<Teclado> Teclado { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //   modelBuilder.Configurations.Add(new ATMConfiguration());

            modelBuilder.Configurations.Add(new AtmConfiguration());
            modelBuilder.Configurations.Add(new BaseDatosConfiguration());
            modelBuilder.Configurations.Add(new CuentaConfiguration());
            modelBuilder.Configurations.Add(new DispensadorEfectivoConfiguration());
            modelBuilder.Configurations.Add(new PantallaConfiguration());
            modelBuilder.Configurations.Add(new RanuraDepositoConfiguration());
            modelBuilder.Configurations.Add(new RetiroConfiguration());
            modelBuilder.Configurations.Add(new TecladoConfiguration());



            Database.SetInitializer<CajeroDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}
