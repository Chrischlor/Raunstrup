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
    public class AdressesController : Controller
    {
        private readonly reinstdbContext _context;

        public AdressesController(reinstdbContext context)
        {
            _context = context;
        }

        // GET: Adresses
        public async Task<IActionResult> Index()
        {
            var reinstdbContext = _context.Adresse.Include(a => a.By);
            return View(await reinstdbContext.ToListAsync());
        }
        // GET: Adresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresse
                .Include(a => a.By)
                .FirstOrDefaultAsync(m => m.Aid == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }
        private void PopulateBynavnDropDownList(object selectedBy = null)
        {
            var ByQuery = from d in _context.Bynavn
                             orderby d.Navn
                          select d;
            ViewBag.Byid = new SelectList(ByQuery.AsNoTracking(), "Byid", "Navn", selectedBy);
        }

        // GET: Adresses/Create
        public IActionResult Create()
        {
            PopulateBynavnDropDownList();
            return View();
        }

        // POST: Adresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aid,Byid,Vejnavn,Husnummer")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateBynavnDropDownList(adresse.Byid);
            return View(adresse);
        }

        // GET: Adresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }
            PopulateBynavnDropDownList();
            return View(adresse);
        }

        // POST: Adresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Aid,Byid,Vejnavn,Husnummer")] Adresse adresse)
        {
            if (id != adresse.Aid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdresseExists(adresse.Aid))
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
            ViewData["Byid"] = new SelectList(_context.Bynavn, "Byid", "Byid", adresse.Byid);
            return View(adresse);
        }

        // GET: Adresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresse
                .Include(a => a.By)
                .FirstOrDefaultAsync(m => m.Aid == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adresse = await _context.Adresse.FindAsync(id);
            _context.Adresse.Remove(adresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdresseExists(int id)
        {
            return _context.Adresse.Any(e => e.Aid == id);
        }
    }
}
