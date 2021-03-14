using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Corrente.Models;

namespace Corrente.Controllers
{
    public class TiposInstituicaoController : Controller
    {
        public IActionResult Index()
        {
            List<TipoInstituicao> listTipoInstituicao = new List<TipoInstituicao>();
            listTipoInstituicao.Add(new TipoInstituicao { Id = 1, Name = "Cultura" });
            listTipoInstituicao.Add(new TipoInstituicao { Id = 2, Name = "Saúde" });
            listTipoInstituicao.Add(new TipoInstituicao { Id = 3, Name = "Assistencia Social" });

            return View(listTipoInstituicao);
        }
    }
}
