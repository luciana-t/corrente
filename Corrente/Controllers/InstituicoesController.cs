using Corrente.Models;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            _instituicaoService.Insert(instituicao);
            return RedirectToAction(nameof(Index));
        }
    }
}
