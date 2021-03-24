using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Corrente.Data;
using Corrente.Models;

namespace Corrente.Controllers
{
    public class TiposInstituicoesController : Controller
    {
        private readonly CorrenteContext _context;

        public TiposInstituicoesController(CorrenteContext context)
        {
            _context = context;
        }

        // GET: TiposInstituicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInstituicao.ToListAsync());
        }

        // GET: TiposInstituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInstituicao = await _context.TipoInstituicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoInstituicao == null)
            {
                return NotFound();
            }

            return View(tipoInstituicao);
        }

        // GET: TiposInstituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposInstituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TipoInstituicao tipoInstituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInstituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInstituicao);
        }

        // GET: TiposInstituicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInstituicao = await _context.TipoInstituicao.FindAsync(id);
            if (tipoInstituicao == null)
            {
                return NotFound();
            }
            return View(tipoInstituicao);
        }

        // POST: TiposInstituicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TipoInstituicao tipoInstituicao)
        {
            if (id != tipoInstituicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInstituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInstituicaoExists(tipoInstituicao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInstituicao);
        }

        // GET: TiposInstituicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInstituicao = await _context.TipoInstituicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoInstituicao == null)
            {
                return NotFound();
            }

            return View(tipoInstituicao);
        }

        // POST: TiposInstituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInstituicao = await _context.TipoInstituicao.FindAsync(id);
            _context.TipoInstituicao.Remove(tipoInstituicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInstituicaoExists(int id)
        {
            return _context.TipoInstituicao.Any(e => e.Id == id);
        }
    }
}
