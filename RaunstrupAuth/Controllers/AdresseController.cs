﻿using System;
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
    public class AdresseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdresseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adresse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adresse.Include(a => a.By);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresse
                .Include(a => a.By)
                .FirstOrDefaultAsync(m => m.AID == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }

        // GET: Adresse/Create
        public IActionResult Create()
        {
            ViewData["Byid"] = new SelectList(_context.Bynavn, "ByID", "ByID");
            return View();
        }

        // POST: Adresse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AID,Byid,Vejnavn,Husnummer")] Adresse adresse, Bynavn bynavn)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(adresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Byid"] = new SelectList(_context.Bynavn, "ByID", "ByID", adresse.Byid);
            return Redirect("/kunde/Create");
                //View(adresse);
        }

        // GET: Adresse/Edit/5
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
            ViewData["Byid"] = new SelectList(_context.Bynavn, "ByID", "ByID", adresse.Byid);
            return View(adresse);
        }

        // POST: Adresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AID,Byid,Vejnavn,Husnummer")] Adresse adresse)
        {
            if (id != adresse.AID)
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
                    if (!AdresseExists(adresse.AID))
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
            ViewData["Byid"] = new SelectList(_context.Bynavn, "ByID", "ByID", adresse.Byid);
            return View(adresse);
        }

        // GET: Adresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresse
                .Include(a => a.By)
                .FirstOrDefaultAsync(m => m.AID == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }

        // POST: Adresse/Delete/5
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
            return _context.Adresse.Any(e => e.AID == id);
        }
    }
}
