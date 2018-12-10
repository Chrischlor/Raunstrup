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
    public class SpecialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Speciales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speciale.ToListAsync());
        }

        // GET: Speciales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciale = await _context.Speciale
                .FirstOrDefaultAsync(m => m.Spid == id);
            if (speciale == null)
            {
                return NotFound();
            }

            return View(speciale);
        }

        // GET: Speciales/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Speciales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Spid,SpecialeNavn")] Speciale speciale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speciale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciale);
        }

        // GET: Speciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciale = await _context.Speciale.FindAsync(id);
            if (speciale == null)
            {
                return NotFound();
            }

            return View(speciale);
        }

        // POST: Speciales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Spid,SpecialeNavn")] Speciale speciale)
        {
            if (id != speciale.Spid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speciale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialeExists(speciale.Spid))
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
            return View(speciale);
        }

        // GET: Speciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciale = await _context.Speciale
                .FirstOrDefaultAsync(m => m.Spid == id);
            if (speciale == null)
            {
                return NotFound();
            }

            return View(speciale);
        }

        // POST: Speciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speciale = await _context.Speciale.FindAsync(id);
            _context.Speciale.Remove(speciale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialeExists(int id)
        {
            return _context.Speciale.Any(e => e.Spid == id);
        }


    }
}
