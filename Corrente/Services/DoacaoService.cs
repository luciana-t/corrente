using Corrente.Data;
using Corrente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Corrente.Services
{
    public class DoacaoService 
    {
        private readonly CorrenteContext _context;

        public DoacaoService(CorrenteContext context)
        {
            _context = context;
        }

        public async Task<List<Doacao>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Doacao select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DtCriada >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DtCriada <= maxDate.Value);
            }
            return await result
                .Include(x => x.Instituicao)
                .Include(x => x.Instituicao.TipoInstituicao)
                .OrderByDescending(x => x.DtCriada)
                .ToListAsync();
        }

        public async Task<List<IGrouping<TipoInstituicao,Doacao>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Doacao select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DtCriada >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DtCriada <= maxDate.Value);
            }
            return await result
                .Include(x => x.Instituicao)
                .Include(x => x.Instituicao.TipoInstituicao)
                .OrderByDescending(x => x.DtCriada)
                .GroupBy(x => x.Instituicao.TipoInstituicao)
                .ToListAsync();
        }
    }
}
