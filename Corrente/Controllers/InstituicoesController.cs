using Corrente.Models;
using Corrente.Models.ViewModels;
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
        public readonly TipoInstituicaoService _tipoInstituicaoService;
        public InstituicoesController(InstituicaoService instituicaoService, TipoInstituicaoService tipoInstituicaoService)
        {
            _instituicaoService = instituicaoService;
            _tipoInstituicaoService = tipoInstituicaoService;
        }

        public IActionResult Index()
        {
            var list = _instituicaoService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var tipoInstituicoes = _tipoInstituicaoService.FindAll();
            var viewModel = new InstituicaoFormViewModel { TipoInstituicoes = tipoInstituicoes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            _instituicaoService.Insert(instituicao);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id) //Same name View
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _instituicaoService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _instituicaoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
