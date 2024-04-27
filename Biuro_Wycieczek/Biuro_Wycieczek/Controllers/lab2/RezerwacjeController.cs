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
    public class RezerwacjeController : Controller
    {
        private readonly BiuroContext _context;

        public RezerwacjeController(BiuroContext context)
        {
            _context = context;
        }

        // GET: Rezerwacje
        public async Task<IActionResult> Index()
        {
              return _context.Reservations != null ? 
                          View(await _context.Reservations.ToListAsync()) :
                          Problem("Entity set 'BiuroContext.Rezerwacje'  is null.");
        }

        // GET: Rezerwacje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezerwacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRezerwacji,DataRezerwacji")] Reservation rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Reservations.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRezerwacji,DataRezerwacji")] Reservation rezerwacja)
        {
            if (id != rezerwacja.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.ReservationId))
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
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'BiuroContext.Rezerwacje'  is null.");
            }
            var rezerwacja = await _context.Reservations.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Reservations.Remove(rezerwacja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
