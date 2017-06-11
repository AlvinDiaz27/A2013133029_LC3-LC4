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
    public class RanuraDepositoConfiguration : EntityTypeConfiguration<RanuraDeposito>
    {
        public RanuraDepositoConfiguration()
        {

            ToTable("RanuraDeposito");

            HasKey(a => a.RanuraDepositoId);
            Property(c => c.RanuraDepositoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }


    }
}
