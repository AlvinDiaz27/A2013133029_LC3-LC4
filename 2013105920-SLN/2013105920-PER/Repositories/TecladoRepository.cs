using _2013105920_ENT.Entities;
using _2013105920_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013105920_PER.Repositories
{
    public class TecladoRepository : Repository<Teclado>, ITecladoRepository
    {
        public TecladoRepository(CajeroDbContext context) : base(context)
        {

        }
    }
}
