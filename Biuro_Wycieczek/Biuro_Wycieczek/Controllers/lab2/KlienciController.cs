﻿using System;
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
    public class KlienciController : Controller
    {
        private readonly BiuroContext _context;

        public KlienciController(BiuroContext context)
        {
            _context = context;
        }

        // GET: Klienci
        public async Task<IActionResult> Index()
        {
              return _context.Clients != null ? 
                          View(await _context.Clients.ToListAsync()) :
                          Problem("Entity set 'BiuroContext.Klienci'  is null.");
        }

        // GET: Klienci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var klient = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // GET: Klienci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klienci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKlienta,Imie,Nazwisko,Kontakt")] Client klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klienci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var klient = await _context.Clients.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klienci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKlienta,Imie,Nazwisko,Kontakt")] Client klient)
        {
            if (id != klient.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.ClientId))
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
            return View(klient);
        }

        // GET: Klienci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var klient = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'BiuroContext.Klienci'  is null.");
            }
            var klient = await _context.Clients.FindAsync(id);
            if (klient != null)
            {
                _context.Clients.Remove(klient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
          return (_context.Clients?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
