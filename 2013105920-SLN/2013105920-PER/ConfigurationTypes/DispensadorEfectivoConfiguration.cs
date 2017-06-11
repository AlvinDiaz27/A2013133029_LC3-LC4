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
    public class DispensadorEfectivoConfiguration : EntityTypeConfiguration<DispensadorEfectivo>
    {
        public DispensadorEfectivoConfiguration()
        {

            ToTable("DispensadorEfectivo");

            HasKey(a => a.DispensadorefectivoId);
            Property(c => c.DispensadorefectivoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Retiro
            HasOptional(c => c.Retiro).WithRequired(c => c.Dispensadorefectivo);
        }



    }
}
