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
    public class DVDController : Controller
    {
        private readonly MvcLocadoraContext _context;

        public DVDController(MvcLocadoraContext context)
        {
            _context = context;
        }

        // GET: DVD
        public async Task<IActionResult> Listar()
        {
            return View(await _context.DVD.ToListAsync());
        }

        // GET: DVD/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        // GET: DVD/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: DVD/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("ID")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(dVD);
        }

        // GET: DVD/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD.FindAsync(id);
            if (dVD == null)
            {
                return NotFound();
            }
            return View(dVD);
        }

        // POST: DVD/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID")] DVD dVD)
        {
            if (id != dVD.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDExists(dVD.ID))
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
            return View(dVD);
        }

        // GET: DVD/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        // POST: DVD/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmed(int id)
        {
            var dVD = await _context.DVD.FindAsync(id);
            _context.DVD.Remove(dVD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool DVDExists(int id)
        {
            return _context.DVD.Any(e => e.ID == id);
        }
    }
}
