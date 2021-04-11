using Corrente.Data;
using Corrente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corrente.Services.Exceptions;

namespace Corrente.Services
{
    public class InstituicaoService
    {
        private readonly CorrenteContext _context;

        public InstituicaoService(CorrenteContext context)
        {
            _context = context;
        }

        public async Task<List<Instituicao>> FindAllAsync()
        {
            return await _context.Instituicao.ToListAsync();
        }

        public async Task InsertAsync(Instituicao obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        } 

        public async Task<Instituicao> FindByIdAsync(int id)
        {
            return await _context.Instituicao.Include(obj =>obj.TipoInstituicao).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync (int id)
        {
            try
            {
                var obj = await _context.Instituicao.FindAsync(id);
                _context.Instituicao.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Os registros de doações dessa instituição serão deletados também");
            }
        }
        public async Task UpdateAsync(Instituicao obj)
        {
            bool hasAny = await _context.Instituicao.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
