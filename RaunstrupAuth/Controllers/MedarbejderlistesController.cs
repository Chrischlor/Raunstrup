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
    public class MedarbejderlistesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedarbejderlistesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medarbejderlistes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medarbejderliste.Include(m => m.M).Include(m => m.R).Include(m => m.T);
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpPost]
        public ActionResult Index(int searchNumber)
        {
            var liste = from m in _context.Medarbejderliste.Include(m => m.M).Include(m => m.R).Include(m => m.T) select m;

            if (searchNumber > 0)
            {
                liste = liste.Where(i => i.Tid == searchNumber);
            }
            return View(liste);
        }

        // GET: Medarbejderlistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderliste = await _context.Medarbejderliste
                .Include(m => m.M)
                .Include(m => m.R)
                .Include(m => m.T)
                .FirstOrDefaultAsync(m => m.Mlid == id);
            if (medarbejderliste == null)
            {
                return NotFound();
            }

            return View(medarbejderliste);
        }

        // GET: Medarbejderlistes/Create
        public IActionResult Create()
        {
            PopulateMedarbejderDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid");
            return View();
        }

        // POST: Medarbejderlistes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mlid,Tid,Mid,Timer,Rid")] Medarbejderliste medarbejderliste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medarbejderliste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMedarbejderDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", medarbejderliste.Tid);
            return View(medarbejderliste);
        }

        // GET: Medarbejderlistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderliste = await _context.Medarbejderliste.FindAsync(id);
            if (medarbejderliste == null)
            {
                return NotFound();
            }
            PopulateMedarbejderDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", medarbejderliste.Tid);
            return View(medarbejderliste);
        }

        // POST: Medarbejderlistes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mlid,Tid,Mid,Timer,Rid")] Medarbejderliste medarbejderliste)
        {
            if (id != medarbejderliste.Mlid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medarbejderliste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedarbejderlisteExists(medarbejderliste.Mlid))
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
            PopulateMedarbejderDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", medarbejderliste.Tid);
            return View(medarbejderliste);
        }

        // GET: Medarbejderlistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderliste = await _context.Medarbejderliste
                .Include(m => m.M)
                .Include(m => m.R)
                .Include(m => m.T)
                .FirstOrDefaultAsync(m => m.Mlid == id);
            if (medarbejderliste == null)
            {
                return NotFound();
            }

            return View(medarbejderliste);
        }

        // POST: Medarbejderlistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medarbejderliste = await _context.Medarbejderliste.FindAsync(id);
            _context.Medarbejderliste.Remove(medarbejderliste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedarbejderlisteExists(int id)
        {
            return _context.Medarbejderliste.Any(e => e.Mlid == id);
        }

        //Udfylder medarbejder dropdown på /create og på /edit/?
        private void PopulateMedarbejderDropDownList(object selectedMedarbejder = null)
        {
            var MedarbejderQuery = from d in _context.Medarbejder
                             orderby d.Navn
                             select d;
            ViewBag.Mid = new SelectList(MedarbejderQuery.AsNoTracking(), "Mid", "Navn", selectedMedarbejder);
        }

        //udfylder rabat dropdown på /create og på /edit/?
        private void PopulateRabatDropDownList(object selectedRabat = null)
        {
            var RabatQuery = from d in _context.Rabat
                             orderby d.rabat
                             select d;
            ViewBag.Rid = new SelectList(RabatQuery.AsNoTracking(), "Rid", "rabat", selectedRabat);
        }
    }
}
