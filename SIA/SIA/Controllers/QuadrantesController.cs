using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIA.Data;
using SIA.Models;

namespace SIA.Controllers
{
    public class QuadrantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuadrantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quadrantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quadrante.ToListAsync());
        }

        // GET: Quadrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrante = await _context.Quadrante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrante == null)
            {
                return NotFound();
            }

            return View(quadrante);
        }

        // GET: Quadrantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quadrantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GrupoId,Nome,Pontuacao,Cor")] Quadrante quadrante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quadrante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quadrante);
        }

        // GET: Quadrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrante = await _context.Quadrante.FindAsync(id);
            if (quadrante == null)
            {
                return NotFound();
            }
            return View(quadrante);
        }

        // POST: Quadrantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GrupoId,Nome,Pontuacao,Cor")] Quadrante quadrante)
        {
            if (id != quadrante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quadrante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuadranteExists(quadrante.Id))
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
            return View(quadrante);
        }

        // GET: Quadrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrante = await _context.Quadrante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrante == null)
            {
                return NotFound();
            }

            return View(quadrante);
        }

        // POST: Quadrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quadrante = await _context.Quadrante.FindAsync(id);
            _context.Quadrante.Remove(quadrante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuadranteExists(int id)
        {
            return _context.Quadrante.Any(e => e.Id == id);
        }
    }
}
