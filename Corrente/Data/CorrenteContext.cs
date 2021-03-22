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

        public DbSet<TipoInstituicao> TipoInstituicao { get; set; }
        public DbSet<Instituicao> Instituicao{ get; set; }
        public DbSet<Doacao> Doacao { get; set; }
    }
}
