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
    public class SessaoController : Controller
    {
        private readonly MvcLocadoraContext _context;

        public SessaoController(MvcLocadoraContext context)
        {
            _context = context;
        }

        // GET: Sessao
        public async Task<IActionResult> Listar()
        {
            return View(await _context.Sessao.ToListAsync());
        }

        // GET: Sessao/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // GET: Sessao/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Sessao/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("ID,Descricao,Localizacao")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(sessao);
        }

        // GET: Sessao/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao.FindAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }
            return View(sessao);
        }

        // POST: Sessao/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID,Descricao,Localizacao")] Sessao sessao)
        {
            if (id != sessao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.ID))
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
            return View(sessao);
        }

        // GET: Sessao/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // POST: Sessao/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmed(int id)
        {
            var sessao = await _context.Sessao.FindAsync(id);
            _context.Sessao.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessao.Any(e => e.ID == id);
        }
    }
}
