using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corrente.Models;
using Corrente.Models.Enums;

namespace Corrente.Data
{
    public class SeedingService
    {
        private CorrenteContext _context;

        public SeedingService(CorrenteContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.TipoInstituicao.Any() ||
                _context.Instituicao.Any() ||
                _context.Doacao.Any())
            {
                return; // DB já populado
            }

            TipoInstituicao t1 = new TipoInstituicao(1, "Saude");
            TipoInstituicao t2 = new TipoInstituicao(2, "Educacao");
            TipoInstituicao t3 = new TipoInstituicao(3, "Entretenimento");
            TipoInstituicao t4 = new TipoInstituicao(4, "Idosos");

            Instituicao i1 = new Instituicao(1, "Hospital da Baleia", "Cuidando de todos", 4.8, new DateTime(2021, 5, 5), "(31) 99999-9999", t1);
            Instituicao i2 = new Instituicao(2, "Casa do Jovem", "Educando jovens", 4.9, new DateTime(2021, 4, 4), "(31) 99999-9999", t2);
            Instituicao i3 = new Instituicao(3, "Cinema Jardim", "Todo filme para todos", 4.7, new DateTime(2021, 3, 3), "(31) 99999-9999", t3);
            Instituicao i4 = new Instituicao(4, "Lar dos Velhinhos", "Acolhe idosos", 4.5, new DateTime(2021, 2, 2), "(31) 99999-9999", t4);

            //int id, DateTime dtCriada, DateTime dtRealizada, DoacaoStatus status, Instituicao instituicao)
            Doacao d1 = new Doacao(1, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Cancelado, i1);
            Doacao d2 = new Doacao(2, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Concluido, i2);
            Doacao d3 = new Doacao(3, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Concluido, i3);
            Doacao d4 = new Doacao(4, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Pendente, i4);
            Doacao d5 = new Doacao(5, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Pendente, i1);
            Doacao d6 = new Doacao(6, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Cancelado, i2);
            Doacao d7 = new Doacao(7, new DateTime(2021, 7, 7), new DateTime(2021, 7, 7), DoacaoStatus.Cancelado, i2);

            _context.TipoInstituicao.AddRange(t1, t2, t3, t4);
            _context.Instituicao.AddRange(i1, i2, i3 , i4);
            _context.Doacao.AddRange(d1, d2, d3, d4, d5, d6, d7);
            _context.SaveChanges();
        }
    }
}
