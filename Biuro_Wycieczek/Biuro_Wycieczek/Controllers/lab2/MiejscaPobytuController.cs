/*using System;
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
    public class MiejscaPobytuController : Controller
    {
        private readonly BiuroContext _context;

        public MiejscaPobytuController(BiuroContext context)
        {
            _context = context;
        }

        // GET: MiejscaPobytu
        public async Task<IActionResult> Index()
        {
              return _context.Miejsca_Pobytu != null ? 
                          View(await _context.Miejsca_Pobytu.ToListAsync()) :
                          Problem("Entity set 'BiuroContext.Miejsca_Pobytu'  is null.");
        }

        // GET: MiejscaPobytu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miejsca_Pobytu == null)
            {
                return NotFound();
            }

            var miejsce_Pobytu = await _context.Miejsca_Pobytu
                .FirstOrDefaultAsync(m => m.MiejsceId == id);
            if (miejsce_Pobytu == null)
            {
                return NotFound();
            }

            return View(miejsce_Pobytu);
        }

        // GET: MiejscaPobytu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiejscaPobytu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiejsceId,Nazwa,Typ,Odleglosc_Od_Morza,basen,parking,Miasto,Ulica,NrLokalu")] MiejscePobytu miejsce_Pobytu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miejsce_Pobytu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miejsce_Pobytu);
        }

        // GET: MiejscaPobytu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miejsca_Pobytu == null)
            {
                return NotFound();
            }

            var miejsce_Pobytu = await _context.Miejsca_Pobytu.FindAsync(id);
            if (miejsce_Pobytu == null)
            {
                return NotFound();
            }
            return View(miejsce_Pobytu);
        }

        // POST: MiejscaPobytu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiejsceId,Nazwa,Typ,Odleglosc_Od_Morza,basen,parking,Miasto,Ulica,NrLokalu")] MiejscePobytu miejsce_Pobytu)
        {
            if (id != miejsce_Pobytu.MiejsceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miejsce_Pobytu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Miejsce_PobytuExists(miejsce_Pobytu.MiejsceId))
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
            return View(miejsce_Pobytu);
        }

        // GET: MiejscaPobytu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miejsca_Pobytu == null)
            {
                return NotFound();
            }

            var miejsce_Pobytu = await _context.Miejsca_Pobytu
                .FirstOrDefaultAsync(m => m.MiejsceId == id);
            if (miejsce_Pobytu == null)
            {
                return NotFound();
            }

            return View(miejsce_Pobytu);
        }

        // POST: MiejscaPobytu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Miejsca_Pobytu == null)
            {
                return Problem("Entity set 'BiuroContext.Miejsca_Pobytu'  is null.");
            }
            var miejsce_Pobytu = await _context.Miejsca_Pobytu.FindAsync(id);
            if (miejsce_Pobytu != null)
            {
                _context.Miejsca_Pobytu.Remove(miejsce_Pobytu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Miejsce_PobytuExists(int id)
        {
          return (_context.Miejsca_Pobytu?.Any(e => e.MiejsceId == id)).GetValueOrDefault();
        }
    }
}
*/