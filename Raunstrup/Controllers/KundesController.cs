using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup.Models;

namespace Raunstrup.Controllers
{
    public class KundesController : Controller
    {
        private readonly reinstdbContext _context;

        public KundesController(reinstdbContext context)
        {
            _context = context;
        }

        // GET: Kundes
        public async Task<IActionResult> Index()
        {
            var reinstdbContext = _context.Kunde.Include(k => k.A);
            return View(await reinstdbContext.ToListAsync());
        }

        // GET: Kundes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde
                .Include(k => k.A)
                .FirstOrDefaultAsync(m => m.Kid == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // GET: Kundes/Create
        public IActionResult Create()
        {
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid");
            return View();
        }

        // POST: Kundes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kid,Navn,Aid,Tlf,Mail")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kunde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", kunde.Aid);
            return View(kunde);
        }

        // GET: Kundes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", kunde.Aid);
            return View(kunde);
        }

        // POST: Kundes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kid,Navn,Aid,Tlf,Mail")] Kunde kunde)
        {
            if (id != kunde.Kid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kunde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundeExists(kunde.Kid))
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
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", kunde.Aid);
            return View(kunde);
        }

        // GET: Kundes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde
                .Include(k => k.A)
                .FirstOrDefaultAsync(m => m.Kid == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // POST: Kundes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kunde = await _context.Kunde.FindAsync(id);
            _context.Kunde.Remove(kunde);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundeExists(int id)
        {
            return _context.Kunde.Any(e => e.Kid == id);
        }
    }
}
