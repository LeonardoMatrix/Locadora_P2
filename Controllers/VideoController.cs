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
    public class VideoController : Controller
    {
        private readonly MvcLocadoraContext _context;

        public VideoController(MvcLocadoraContext context)
        {
            _context = context;
        }

        // GET: Video
        public async Task<IActionResult> Listar()
        {
            return View(await _context.Videos.ToListAsync());
        }

        // GET: Video/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.CodigoVideo == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Video/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Video/Criar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("CodigoVideo,Titulo,Disponibilidade,QuantidadeEstoque,Genero")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(video);
        }

        // GET: Video/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Video/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhar see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("CodigoVideo,Titulo,Disponibilidade,QuantidadeEstoque,Genero")] Video video)
        {
            if (id != video.CodigoVideo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.CodigoVideo))
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
            return View(video);
        }

        // GET: Video/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.CodigoVideo == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Video/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmed(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.CodigoVideo == id);
        }
    }
}
