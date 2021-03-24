using System;
using System.Collections.Generic;
using System.Linq;

namespace Corrente.Models
{
    public class TipoInstituicao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Instituicao> Instituicoes { get; set; } = new List<Instituicao>();

        public TipoInstituicao() { }

        public TipoInstituicao(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddInstituicao(Instituicao instituicao)
        {
            Instituicoes.Add(instituicao);
        }

        public List<Instituicao> ListInstituicao(DateTime inicial, DateTime final)
        {
            return Instituicoes.Where(i => i.DtCadastro >= inicial && i.DtCadastro <= final).ToList();
        }
    }
}
