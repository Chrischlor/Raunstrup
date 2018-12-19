using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaunstrupAuth.Data;
using RaunstrupAuth.Models;
using System.IO;

namespace RaunstrupAuth.Controllers
{
    public class MedarbejdereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedarbejdereController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medarbejdere
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medarbejder.Include(m => m.A).Include(m => m.Sp);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Medarbejdere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var medarbejder = await _context.Medarbejder
                .Include(m => m.A)
                .Include(m => m.Sp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            return View(medarbejder);
        }

        // GET: Medarbejdere/Create
        public IActionResult Create()
        {
            PopulateAdresseDropDownList();
            PopulateSpecialeDropDownList();
            return View();
        }

        // POST: Medarbejdere/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mid,Navn,Aid,Tlf,Udd,Fudd,Spid")] Medarbejder medarbejder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medarbejder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aid"] = new SelectList(_context.Set<Bynavn>(), "Aid", "Aid", medarbejder.Aid);
            ViewData["Spid"] = new SelectList(_context.Speciale, "Spid", "Spid", medarbejder.Spid);
            return View(medarbejder);
        }

        // GET: Medarbejdere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var medarbejder = await _context.Medarbejder.FindAsync(id);
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }
            PopulateAdresseDropDownList();
            PopulateSpecialeDropDownList();
            return View(medarbejder);
        }

        // POST: Medarbejdere/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mid,Navn,Aid,Tlf,Udd,Fudd,Spid")] Medarbejder medarbejder)
        {
            if (id != medarbejder.Mid)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medarbejder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedarbejderExists(medarbejder.Mid))
                    {
                        return RedirectToAction(actionName: nameof(Index),
                            controllerName: "Home");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", medarbejder.Aid);
            ViewData["Spid"] = new SelectList(_context.Speciale, "Spid", "Spid", medarbejder.Spid);
            return View(medarbejder);
        }

        // GET: Medarbejdere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var medarbejder = await _context.Medarbejder
                .Include(m => m.A)
                .Include(m => m.Sp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (medarbejder == null)
            {
                  return RedirectToAction(actionName: nameof(Index),
                      controllerName: "Home");
               
            }

            return View(medarbejder);
        }

        // POST: Medarbejdere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medarbejder = await _context.Medarbejder.FindAsync(id);
            _context.Medarbejder.Remove(medarbejder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedarbejderExists(int id)
        {
            return _context.Medarbejder.Any(e => e.Mid == id);
        }

        private void PopulateAdresseDropDownList(object selectedAdresse = null)
        {
            var kundeQuery = from d in _context.Adresse
                             orderby d.Vejnavn
                             select d;
            ViewBag.Aid = new SelectList(kundeQuery.AsNoTracking(), "Aid", "Vejnavn", selectedAdresse);
        }
        private void PopulateSpecialeDropDownList(object selectedSpeciale = null)
        {
            var kundeQuery = from d in _context.Speciale
                             orderby d.SpecialeNavn
                             select d;
            ViewBag.Spid = new SelectList(kundeQuery.AsNoTracking(), "Spid", "SpecialeNavn", selectedSpeciale);
        }
    }
}
