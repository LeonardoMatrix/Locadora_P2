using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class AtorController : Controller
    {
        private readonly MvcLocadoraContext _context;

        public AtorController(MvcLocadoraContext context)
        {
            _context = context;
        }

        // GET: Ator
        public async Task<IActionResult> Listar()
        {
            return View(await _context.Ator.ToListAsync());
        }

        // GET: Ator/Details/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // GET: Ator/Create
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Ator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("ID,AtorPrincipal")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(ator);
        }

        // GET: Ator/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator.FindAsync(id);
            if (ator == null)
            {
                return NotFound();
            }
            return View(ator);
        }

        // POST: Ator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID,AtorPrincipal")] Ator ator)
        {
            if (id != ator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtorExists(ator.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Listar));
            }
            return View(ator);
        }

        // GET: Ator/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // POST: Ator/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ator = await _context.Ator.FindAsync(id);
            _context.Ator.Remove(ator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool AtorExists(int id)
        {
            return _context.Ator.Any(e => e.ID == id);
        }
    }
}
