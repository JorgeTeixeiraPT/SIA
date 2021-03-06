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
    public class TecnicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TecnicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tecnicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tecnica.Include(t => t.Quadrante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tecnicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnica = await _context.Tecnica
                .Include(t => t.Quadrante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnica == null)
            {
                return NotFound();
            }

            return View(tecnica);
        }

        // GET: Tecnicas/Create
        public IActionResult Create()
        {
            ViewData["QuadranteId"] = new SelectList(_context.Quadrante, "Id", "Id");
            return View();
        }

        // POST: Tecnicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,QuadranteId")] Tecnica tecnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuadranteId"] = new SelectList(_context.Quadrante, "Id", "Id", tecnica.QuadranteId);
            return View(tecnica);
        }

        // GET: Tecnicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnica = await _context.Tecnica.FindAsync(id);
            if (tecnica == null)
            {
                return NotFound();
            }
            ViewData["QuadranteId"] = new SelectList(_context.Quadrante, "Id", "Id", tecnica.QuadranteId);
            return View(tecnica);
        }

        // POST: Tecnicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,QuadranteId")] Tecnica tecnica)
        {
            if (id != tecnica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicaExists(tecnica.Id))
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
            ViewData["QuadranteId"] = new SelectList(_context.Quadrante, "Id", "Id", tecnica.QuadranteId);
            return View(tecnica);
        }

        // GET: Tecnicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnica = await _context.Tecnica
                .Include(t => t.Quadrante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnica == null)
            {
                return NotFound();
            }

            return View(tecnica);
        }

        // POST: Tecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnica = await _context.Tecnica.FindAsync(id);
            _context.Tecnica.Remove(tecnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicaExists(int id)
        {
            return _context.Tecnica.Any(e => e.Id == id);
        }
    }
}
