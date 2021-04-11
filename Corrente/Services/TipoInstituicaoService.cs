using Corrente.Data;
using Corrente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Corrente.Services
{
    public class TipoInstituicaoService
    {
        private readonly CorrenteContext _context;

        public TipoInstituicaoService(CorrenteContext context)
        {
            _context = context;
        }
        
        public async Task<List<TipoInstituicao>> FindAllAsync()
        {
            return await _context.TipoInstituicao.OrderBy(x => x.Name).ToListAsync();        
        }

    }
}
