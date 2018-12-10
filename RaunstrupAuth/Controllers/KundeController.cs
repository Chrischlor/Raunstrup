using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaunstrupAuth.Data;
using RaunstrupAuth.Models;

namespace RaunstrupAuth.Controllers
{
    public class KundeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KundeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kunde
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kunde.Include(k => k.A);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kunde/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde
                .Include(k => k.A)
                .ThenInclude(A => A.Aid)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Kid == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // GET: Kunde/Create
        public IActionResult Create()
        {
            ViewData["Navn"] = new SelectList(_context.Set<Bynavn>(), "Navn", "Navn");
            return View();
        }

        // POST: Kunde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kid,Byid,Navn,Tlf,Mail")] Kunde kunde, [Bind("Vejnavn, Husnummer")]Adresse A, [Bind("Navn, Byid")] Bynavn b)
        {
            if (ModelState.IsValid)
            {
                A.Byid = b.Byid;
                //_context.Add(b);
                _context.Add(A);
                _context.Add(kunde);
                
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Navn"] = new SelectList(_context.Set<Bynavn>(), "Navn", "Navn", b.Navn);
            return View(kunde);
        }

        // GET: Kunde/Edit/5
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
            ViewData["Aid"] = new SelectList(_context.Set<Adresse>(), "AID", "AID", kunde.Aid);
            return View(kunde);
        }

        // POST: Kunde/Edit/5
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
            ViewData["Aid"] = new SelectList(_context.Set<Adresse>(), "AID", "AID", kunde.Aid);
            return View(kunde);
        }

        // GET: Kunde/Delete/5
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

        // POST: Kunde/Delete/5
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
