using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Corrente.Models
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Pontuação")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double Pontuacao { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtCadastro { get; set; }
        //public Reference Icone { get; set; }
        //public Reference Social { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Tipo de Instituição")]
        public TipoInstituicao TipoInstituicao { get; set; }

        [Display(Name = "Tipo de Instituição")]
        public int TipoInstituicaoId { get; set; }

        [Display(Name = "Doações")]
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
