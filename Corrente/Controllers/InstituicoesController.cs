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

        public async Task<IActionResult> Index()
        {
            var list = await _instituicaoService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var tipoInstituicoes = await _tipoInstituicaoService.FindAllAsync();
            var viewModel = new InstituicaoFormViewModel { TipoInstituicoes = tipoInstituicoes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instituicao instituicao)
        {
            if (!ModelState.IsValid)
            {
                var tipoInstituicoes = await _tipoInstituicaoService.FindAllAsync();
                var ViewModel = new InstituicaoFormViewModel { Instituicao = instituicao, TipoInstituicoes = tipoInstituicoes };
                return View(ViewModel);
            }
            await _instituicaoService.InsertAsync(instituicao);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (int? id) //Same name View
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _instituicaoService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _instituicaoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not proided" });
            }

            var obj = await _instituicaoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _instituicaoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<TipoInstituicao> tiposInstituicao = await _tipoInstituicaoService.FindAllAsync();
            InstituicaoFormViewModel viewModel = new InstituicaoFormViewModel { Instituicao = obj, TipoInstituicoes = tiposInstituicao };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit (int id, Instituicao instituicao)
        {
            if (!ModelState.IsValid)
            {
                var tipoInstituicoes = await _tipoInstituicaoService.FindAllAsync();
                var ViewModel = new InstituicaoFormViewModel { Instituicao = instituicao, TipoInstituicoes = tipoInstituicoes };
                return View(ViewModel);
            }
            if (id != instituicao.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _instituicaoService.UpdateAsync(instituicao);
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
