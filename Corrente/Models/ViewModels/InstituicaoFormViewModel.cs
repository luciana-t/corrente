using System.Collections.Generic;

namespace Corrente.Models.ViewModels
{
    public class InstituicaoFormViewModel
    {
        public Instituicao Instituicao { get; set; }
        public ICollection<TipoInstituicao> TipoInstituicoes { get; set; }
    }
}
