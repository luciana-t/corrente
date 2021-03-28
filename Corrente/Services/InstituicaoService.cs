using Corrente.Data;
using Corrente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
