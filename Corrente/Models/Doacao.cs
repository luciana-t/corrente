using Corrente.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Corrente.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyy}")]
        public DateTime DtCriada { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyy}")]
        public DateTime DtRealizada { get; set; }
        public DoacaoStatus Status { get; set; }
        //public EnumTODO Tipo { get; set; }
        public Instituicao Instituicao { get; set; }

        public Doacao() { }

        public Doacao(int id, DateTime dtCriada, DateTime dtRealizada, DoacaoStatus status, Instituicao instituicao)
        {
            Id = id;
            DtCriada = dtCriada;
            DtRealizada = dtRealizada;
            Status = status;
            Instituicao = instituicao;
        }
    }
}
