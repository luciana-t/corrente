using Corrente.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corrente.Controllers
{
    public class InstituicoesController : Controller
    {
        private readonly InstituicaoService _instituicaoService;
        public InstituicoesController(InstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        public IActionResult Index()
        {
            var list = _instituicaoService.FindAll();

            return View(list);
        }
    }
}
