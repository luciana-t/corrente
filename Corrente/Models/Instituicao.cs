using System;
using System.Collections.Generic;
using System.Linq;

namespace Corrente.Models
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Pontuacao { get; set; }
        public DateTime DtCadastro { get; set; }
        //public Reference Icone { get; set; }
        //public Reference Social { get; set; }
        public string Telefone { get; set; }
        public TipoInstituicao TipoInstituicao { get; set; }
        public int TipoInstituicaoId { get; set; }
        public ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();

        public Instituicao() { }

        public Instituicao(int id, string nome, string descricao, double pontuacao, DateTime dtCadastro, string telefone, TipoInstituicao tipoInstituicao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Pontuacao = pontuacao;
            DtCadastro = dtCadastro;
            Telefone = telefone;
            TipoInstituicao = tipoInstituicao;
        }

        public void AddDoacao(Doacao doacao)
        {
            Doacoes.Add(doacao);
        }

        public void RemoveDoacao(Doacao doacao) 
        {
            Doacoes.Remove(doacao);
        }

        public int TotalDoacoes(DateTime inicial, DateTime final)
        {
            return Doacoes.Where(d => d.DtRealizada >= inicial && d.DtRealizada <= final).Count();
        }
    }
}
