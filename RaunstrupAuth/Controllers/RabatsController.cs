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
    public class RabatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RabatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rabats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rabat.ToListAsync());
        }

        // GET: Rabats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabat = await _context.Rabat
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (rabat == null)
            {
                return NotFound();
            }

            return View(rabat);
        }

        // GET: Rabats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rabats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rid,rabat")] Rabat R)
        {
            if (ModelState.IsValid)
            {
                _context.Add(R);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(R);
        }

        // GET: Rabats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabat = await _context.Rabat.FindAsync(id);
            if (rabat == null)
            {
                return NotFound();
            }
            return View(rabat);
        }

        // POST: Rabats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rid,rabat")] Rabat R)
        {
            if (id != R.Rid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(R);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RabatExists(R.Rid))
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
            return View(R);
        }

        // GET: Rabats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabat = await _context.Rabat
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (rabat == null)
            {
                return NotFound();
            }

            return View(rabat);
        }

        // POST: Rabats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rabat = await _context.Rabat.FindAsync(id);
            _context.Rabat.Remove(rabat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RabatExists(int id)
        {
            return _context.Rabat.Any(e => e.Rid == id);
        }
    }
}
