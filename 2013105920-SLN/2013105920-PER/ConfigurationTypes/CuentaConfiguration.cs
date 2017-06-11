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
    public class CuentaConfiguration : EntityTypeConfiguration<Cuenta>
    {
        public CuentaConfiguration()
        {

            ToTable("Cuenta");

            HasKey(a => a.CuentaId);
            Property(c => c.CuentaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Nombres)
                .IsRequired()
                .HasMaxLength(100);
            Property(v => v.Apellidos)
                .IsRequired()
                .HasMaxLength(100);
            Property(v => v.NumeroCuenta)
                .IsRequired();
            Property(v => v.pin)
                .IsRequired();
            Property(v => v.saldo)
                .IsRequired();





        }

    }
}
