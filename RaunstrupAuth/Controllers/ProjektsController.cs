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
    public class ProjektsController : Controller
    {
        //opsætter context
        private readonly ApplicationDbContext _context;

        public ProjektsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projekts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Projekt.Include(p => p.Projektleder).Include(p => p.T);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Projekts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt
                .Include(p => p.Projektleder)
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // GET: Projekts/Create
        public IActionResult Create()
        {
            ViewData["Mid"] = new SelectList(_context.Medarbejder, "Mid", "Mid");
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid");
            return View();
        }

        // POST: Projekts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Tid,Mid")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mid"] = new SelectList(_context.Medarbejder, "Mid", "Mid", projekt.Mid);
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", projekt.Tid);
            return View(projekt);
        }

        // GET: Projekts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }
            ViewData["Mid"] = new SelectList(_context.Medarbejder, "Mid", "Mid", projekt.Mid);
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", projekt.Tid);
            return View(projekt);
        }

        // POST: Projekts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,Tid,Mid")] Projekt projekt)
        {
            if (id != projekt.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjektExists(projekt.Pid))
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
            ViewData["Mid"] = new SelectList(_context.Medarbejder, "Mid", "Mid", projekt.Mid);
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", projekt.Tid);
            return View(projekt);
        }

        // GET: Projekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekt
                .Include(p => p.Projektleder)
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // POST: Projekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projekt = await _context.Projekt.FindAsync(id);
            _context.Projekt.Remove(projekt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjektExists(int id)
        {
            return _context.Projekt.Any(e => e.Pid == id);
        }
    }
}
