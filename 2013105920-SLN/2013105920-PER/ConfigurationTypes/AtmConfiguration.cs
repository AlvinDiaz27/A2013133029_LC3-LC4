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
    public class AtmConfiguration : EntityTypeConfiguration<Atm>
    {

        public AtmConfiguration()
        {

            ToTable("ATM");
            HasKey(a => a.AtmId);
            Property(c => c.AtmId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Mensaje).IsRequired().HasMaxLength(200);
            //DispensadorEfectivo
            HasRequired(c => c.dispensadorEfectivo).WithRequiredPrincipal(c => c.Atm);
            //Pantalla
            HasRequired(c => c.pantalla).WithRequiredPrincipal(c => c.Atm);
            //Teclado
            HasRequired(c => c.teclado).WithRequiredPrincipal(c => c.Atm);
            //Retiro
            HasOptional(c => c.Retiro).WithRequired(c => c.Atm);
            //RanuraDeposito
            HasRequired(c => c.ranuradeposito).WithRequiredPrincipal(c => c.Atm);


        }

    }
}
