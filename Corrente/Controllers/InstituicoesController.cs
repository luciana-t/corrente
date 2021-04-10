using Corrente.Models;
using Corrente.Models.ViewModels;
using Corrente.Services;
using Corrente.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _instituicaoService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
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

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not proided" });
            }

            var obj = _instituicaoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _instituicaoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<TipoInstituicao> tiposInstituicao = _tipoInstituicaoService.FindAll();
            InstituicaoFormViewModel viewModel = new InstituicaoFormViewModel { Instituicao = obj, TipoInstituicoes = tiposInstituicao };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit (int id, Instituicao instituicao)
        {
            if (id != instituicao.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _instituicaoService.Update(instituicao);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
