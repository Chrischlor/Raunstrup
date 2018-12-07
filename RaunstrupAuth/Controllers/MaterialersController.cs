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
    public class MaterialersController : Controller
    {
        private readonly reinstdbContext _context;

        public MaterialersController(reinstdbContext context)
        {
            _context = context;
        }

        // GET: Materialers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materialer.ToListAsync());
        }

        // GET: Materialers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialer = await _context.Materialer
                .FirstOrDefaultAsync(m => m.Varenummer == id);
            if (materialer == null)
            {
                return NotFound();
            }

            return View(materialer);
        }

        // GET: Materialers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materialers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Varenummer,Navn,Indkøbspris,Salgspris")] Materialer materialer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialer);
        }

        // GET: Materialers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialer = await _context.Materialer.FindAsync(id);
            if (materialer == null)
            {
                return NotFound();
            }
            return View(materialer);
        }

        // POST: Materialers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Varenummer,Navn,Indkøbspris,Salgspris")] Materialer materialer)
        {
            if (id != materialer.Varenummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialerExists(materialer.Varenummer))
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
            return View(materialer);
        }

        // GET: Materialers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialer = await _context.Materialer
                .FirstOrDefaultAsync(m => m.Varenummer == id);
            if (materialer == null)
            {
                return NotFound();
            }

            return View(materialer);
        }

        // POST: Materialers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialer = await _context.Materialer.FindAsync(id);
            _context.Materialer.Remove(materialer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialerExists(int id)
        {
            return _context.Materialer.Any(e => e.Varenummer == id);
        }
    }
}
