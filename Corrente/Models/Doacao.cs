using Corrente.Models.Enums;
using System;

namespace Corrente.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public DateTime DtCriada { get; set; }
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
