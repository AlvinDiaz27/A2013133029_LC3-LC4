using _2013105920_ENT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_PER.ConfigurationTypes
{
    public class BaseDatosConfiguration : EntityTypeConfiguration<BaseDatos>
    {

        public BaseDatosConfiguration()
        {

            ToTable("BaseDatos");

            HasKey(a => a.BaseDatosId);
            Property(c => c.BaseDatosId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Administrador).IsRequired().HasMaxLength(100);
            Property(c => c.AutentificarCuenta);
            Property(c => c.ObtenerSaldoDisponible);
            Property(c => c.ObtenerSaldoTotal);
            Property(c => c.Debitar);
            Property(c => c.Acreditar);
            //ATM
            HasOptional(c => c.Atm).WithRequired(c => c.BaseDatos);
            //Retiro
            HasOptional(c => c.Retiro).WithRequired(c => c.BaseDatos);
            //Cuenta
   //         HasMany(c => c.ListaCuentas).WithRequired(g => g.BaseDatos).HasForeignKey(v => v.BaseDatosId);
        }

    }
}
