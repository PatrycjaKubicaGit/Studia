using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biuro_Wycieczek.Data;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Controllers
{
    public class PrzewodnicyController : Controller
    {
        private readonly BiuroContext _context;

        public PrzewodnicyController(BiuroContext context)
        {
            _context = context;
        }

        // GET: Przewodnicy
        public async Task<IActionResult> Index()
        {
              return _context.Guides != null ? 
                          View(await _context.Guides.ToListAsync()) :
                          Problem("Entity set 'BiuroContext.Przewodnicy'  is null.");
        }

        // GET: Przewodnicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guides == null)
            {
                return NotFound();
            }

            var przewodnik = await _context.Guides
                .FirstOrDefaultAsync(m => m.GuideId == id);
            if (przewodnik == null)
            {
                return NotFound();
            }

            return View(przewodnik);
        }

        // GET: Przewodnicy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Przewodnicy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrzewodnikId,Imie,Nazwisko,Specjalizacja,Kontakt")] Guide przewodnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(przewodnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(przewodnik);
        }

        // GET: Przewodnicy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guides == null)
            {
                return NotFound();
            }

            var przewodnik = await _context.Guides.FindAsync(id);
            if (przewodnik == null)
            {
                return NotFound();
            }
            return View(przewodnik);
        }

        // POST: Przewodnicy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrzewodnikId,Imie,Nazwisko,Specjalizacja,Kontakt")] Guide przewodnik)
        {
            if (id != przewodnik.GuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(przewodnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrzewodnikExists(przewodnik.GuideId))
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
            return View(przewodnik);
        }

        // GET: Przewodnicy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guides == null)
            {
                return NotFound();
            }

            var przewodnik = await _context.Guides
                .FirstOrDefaultAsync(m => m.GuideId == id);
            if (przewodnik == null)
            {
                return NotFound();
            }

            return View(przewodnik);
        }

        // POST: Przewodnicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guides == null)
            {
                return Problem("Entity set 'BiuroContext.Przewodnicy'  is null.");
            }
            var przewodnik = await _context.Guides.FindAsync(id);
            if (przewodnik != null)
            {
                _context.Guides.Remove(przewodnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrzewodnikExists(int id)
        {
          return (_context.Guides?.Any(e => e.GuideId == id)).GetValueOrDefault();
        }
    }
}
