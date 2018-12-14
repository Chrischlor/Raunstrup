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
    public class TilbudsController : Controller
    {
        //Opsætter context
        private readonly ApplicationDbContext _context;

        public TilbudsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tilbuds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tilbud.Include(t => t.K).Include(t => t.R);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tilbuds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tilbud = await _context.Tilbud
                .Include(t => t.K)
                .Include(t => t.R)
                .Include(t => t.Medarbejderliste)
                .Include(t => t.Indkøbsliste)
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (tilbud == null)
            {
                return NotFound();
            }

            return View(tilbud);
        }

        // GET: Tilbuds/Create
        public IActionResult Create()
        {
            PopulateKundeDropDownList();
            PopulateRabatDropDownList();
            return View();
        }

        // POST: Tilbuds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tid,Projekttitle,Rid,Kid,Startdato,Deadline")] Tilbud tilbud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tilbud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateKundeDropDownList();
            PopulateRabatDropDownList();
            return View(tilbud);
        }

        // GET: Tilbuds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tilbud = await _context.Tilbud.FindAsync(id);
            if (tilbud == null)
            {
                return NotFound();
            }
            PopulateKundeDropDownList();
            PopulateRabatDropDownList();
            return View(tilbud);
        }

        // POST: Tilbuds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tid,Projekttitle,Rid,Kid,Startdato,Deadline")] Tilbud tilbud)
        {
            if (id != tilbud.Tid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tilbud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TilbudExists(tilbud.Tid))
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
            PopulateKundeDropDownList();
            PopulateRabatDropDownList();
            return View(tilbud);
        }

        // GET: Tilbuds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tilbud = await _context.Tilbud
                .Include(t => t.K)
                .Include(t => t.R)
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (tilbud == null)
            {
                return NotFound();
            }

            return View(tilbud);
        }

        // POST: Tilbuds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tilbud = await _context.Tilbud.FindAsync(id);
            _context.Tilbud.Remove(tilbud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TilbudExists(int id)
        {
            return _context.Tilbud.Any(e => e.Tid == id);
        }
        //Udfylder rabat dropdown på /create og på /edit/?
        private void PopulateRabatDropDownList(object selectedRabat = null)
        {
            var RabatQuery = from d in _context.Rabat
                             orderby d.rabat
                             select d;
            ViewBag.Rid = new SelectList(RabatQuery.AsNoTracking(), "Rid", "rabat", selectedRabat);
        }
        //Udfylder kunde dropdown på /create og på /edit/?
        private void PopulateKundeDropDownList(object selectedKunde = null)
        {
            var RabatQuery = from d in _context.Kunde
                             orderby d.Navn
                             select d;
            ViewBag.Kid = new SelectList(RabatQuery.AsNoTracking(), "Kid", "Navn", selectedKunde);
        }
    }
}
