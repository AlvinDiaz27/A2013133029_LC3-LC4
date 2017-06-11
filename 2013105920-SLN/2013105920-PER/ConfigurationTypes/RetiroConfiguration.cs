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
    public class RetiroConfiguration : EntityTypeConfiguration<Retiro>
    {
        public RetiroConfiguration()
        {

            ToTable("Retiro");

            HasKey(a => a.RetiroId);
            Property(c => c.RetiroId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(c => c.Cuentas)
               .WithMany(c => c.Retiros)
               .Map(m =>
               {
                   m.ToTable("CuentaRetiros");
                   m.MapLeftKey("CuentaId");
                   m.MapRightKey("RetiroId");
               });

            Property(v => v.Monto)
                .IsRequired()
                .HasMaxLength(50);


        }



    }
}
