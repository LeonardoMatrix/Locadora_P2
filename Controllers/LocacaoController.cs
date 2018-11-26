using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly MvcLocadoraContext _context;

        public LocacaoController(MvcLocadoraContext context)
        {
            _context = context;
        }

        // GET: Locacao
        public async Task<IActionResult> Listar()
        {
            return View(await _context.Locacao.Include(localizacao => localizacao.Cliente).ToListAsync());
        }

        // GET: Locacao/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao.Include(localizacao => localizacao.Cliente)
                .FirstOrDefaultAsync(m => m.CodigoLocacao == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacao/Criar
        public IActionResult Criar()
        {

            ViewData["Cliente"] = new SelectList(_context.Cliente.ToList(),"CPF", "Nome").Items;
            return View();
        }

        // POST: Locacao/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("CodigoLocacao,DataLocacao,DataDevolucao,Valor,Cliente")] Locacao locacao, IFormCollection collection)
        {

            int cpfCliente = Convert.ToInt16(collection["Cliente"]);

            if (ModelState.IsValid)
            {
                var cliente = await _context.Cliente.FindAsync(cpfCliente);
                locacao.Cliente = cliente;
                _context.Add(locacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(locacao);
        }

        // GET: Locacao/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }
            return View(locacao);
        }

        // POST: Locacao/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("CodigoLocacao,DataLocacao,DataDevolucao,Valor")] Locacao locacao)
        {
            if (id != locacao.CodigoLocacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!LocacaoExists(locacao.CodigoLocacao))
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
            return View(locacao);
        }

        // GET: Locacao/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var locacao = await _context.Locacao.Include(localizacao => localizacao.Cliente)
                .FirstOrDefaultAsync(m => m.CodigoLocacao == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacao/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmed(int id)
        {
            var locacao = await _context.Locacao.FindAsync(id);
            _context.Locacao.Remove(locacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacao.Any(e => e.CodigoLocacao == id);
        }
    }
}
