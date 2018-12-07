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
    public class BynavnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BynavnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bynavn
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bynavn.ToListAsync());
        }

        // GET: Bynavn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bynavn = await _context.Bynavn
                .FirstOrDefaultAsync(m => m.Byid == id);
            if (bynavn == null)
            {
                return NotFound();
            }

            return View(bynavn);
        }

        // GET: Bynavn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bynavn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ByID,Postnummer,Navn")] Bynavn bynavn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bynavn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/Adresse/Create");
                //View(bynavn);
        }

        // GET: Bynavn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bynavn = await _context.Bynavn.FindAsync(id);
            if (bynavn == null)
            {
                return NotFound();
            }
            return View(bynavn);
        }

        // POST: Bynavn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ByID,Postnummer,Navn")] Bynavn bynavn)
        {
            if (id != bynavn.Byid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bynavn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BynavnExists(bynavn.Byid))
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
            return View(bynavn);
        }

        // GET: Bynavn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bynavn = await _context.Bynavn
                .FirstOrDefaultAsync(m => m.Byid == id);
            if (bynavn == null)
            {
                return NotFound();
            }

            return View(bynavn);
        }

        // POST: Bynavn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bynavn = await _context.Bynavn.FindAsync(id);
            _context.Bynavn.Remove(bynavn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BynavnExists(int id)
        {
            return _context.Bynavn.Any(e => e.Byid == id);
        }
    }
}
