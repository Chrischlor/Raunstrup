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
    public class IndkøbslisteController : Controller
    {
        //opsætning af context
        private readonly ApplicationDbContext _context;

        public IndkøbslisteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Indkøbsliste
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Indkøbsliste.Include(i => i.R).Include(i => i.T).Include(i => i.VarenummerNavigation);
            return View(await applicationDbContext.ToListAsync());
        }
        //Indexering af indkøb til search
        [HttpPost]
        public ActionResult Index (int searchNumber)
        {
            var liste = from m in _context.Indkøbsliste.Include( i => i.R).Include(i => i.T).Include(i => i.VarenummerNavigation) select m;
            
            if (searchNumber > 0)
            {
                liste = liste.Where(i => i.Tid == searchNumber);
            }
            return View(liste);
        }

        // GET: Indkøbsliste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indkøbsliste = await _context.Indkøbsliste
                .Include(i => i.R)
                .Include(i => i.T)
                .Include(i => i.VarenummerNavigation)
                .FirstOrDefaultAsync(m => m.Iid == id);
            if (indkøbsliste == null)
            {
                return NotFound();
            }

            return View(indkøbsliste);
        }

        // GET: Indkøbsliste/Create
        public IActionResult Create()
        {
            PopulateMaterialerDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid");
            return View();
        }

        // POST: Indkøbsliste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iid,Tid,Varenummer,Antal,Rid")] Indkøbsliste indkøbsliste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indkøbsliste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMaterialerDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", indkøbsliste.Tid);
            return View(indkøbsliste);
        }

        // GET: Indkøbsliste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indkøbsliste = await _context.Indkøbsliste.FindAsync(id);
            if (indkøbsliste == null)
            {
                return NotFound();
            }
            PopulateMaterialerDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", indkøbsliste.Tid);
            return View(indkøbsliste);
        }

        // POST: Indkøbsliste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iid,Tid,Varenummer,Antal,Rid")] Indkøbsliste indkøbsliste)
        {
            if (id != indkøbsliste.Iid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indkøbsliste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndkøbslisteExists(indkøbsliste.Iid))
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
            PopulateMaterialerDropDownList();
            PopulateRabatDropDownList();
            ViewData["Tid"] = new SelectList(_context.Tilbud, "Tid", "Tid", indkøbsliste.Tid);
            return View(indkøbsliste);
        }

        // GET: Indkøbsliste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indkøbsliste = await _context.Indkøbsliste
                .Include(i => i.R)
                .Include(i => i.T)
                .Include(i => i.VarenummerNavigation)
                .FirstOrDefaultAsync(m => m.Iid == id);
            if (indkøbsliste == null)
            {
                return NotFound();
            }

            return View(indkøbsliste);
        }

        // POST: Indkøbsliste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indkøbsliste = await _context.Indkøbsliste.FindAsync(id);
            _context.Indkøbsliste.Remove(indkøbsliste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndkøbslisteExists(int id)
        {
            return _context.Indkøbsliste.Any(e => e.Iid == id);
        }

        //Udfylning af rabat liste på /create og på /edit/?
        private void PopulateRabatDropDownList(object selectedRabat = null)
        {
            var RabatQuery = from d in _context.Rabat
                             orderby d.rabat
                             select d;
            ViewBag.Rid = new SelectList(RabatQuery.AsNoTracking(), "Rid", "rabat", selectedRabat);
        }
        //Udfyldning af varenummer liste på /create og på /edit/?
        private void PopulateMaterialerDropDownList(object selectedMaterialer = null)
        {
            var MaterialeQuery = from d in _context.Materialer
                             orderby d.Navn
                             select d;
            ViewBag.Varenummer = new SelectList(MaterialeQuery.AsNoTracking(), "Varenummer", "Navn", selectedMaterialer);
        }
    }
}
