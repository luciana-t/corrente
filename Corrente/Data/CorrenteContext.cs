using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corrente.Models;

namespace Corrente.Data
{
    public class CorrenteContext : DbContext
    {
        public CorrenteContext (DbContextOptions<CorrenteContext> options)
            : base(options)
        {
        }

        public DbSet<Corrente.Models.TipoInstituicao> TipoInstituicao { get; set; }
    }
}
