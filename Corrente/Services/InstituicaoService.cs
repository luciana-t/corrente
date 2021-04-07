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

        public List<Instituicao> FindAll()
        {
            return _context.Instituicao.ToList();
        }

        public void Insert(Instituicao obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        } 

        public Instituicao FindById(int id)
        {
            return _context.Instituicao.Include(obj =>obj.TipoInstituicao).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove (int id)
        {
            var obj = _context.Instituicao.Find(id);
            _context.Instituicao.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Instituicao obj)
        {
            if (!_context.Instituicao.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
