//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using RaunstrupAuth.Models;
//using RaunstrupAuth.Data;
//using Microsoft.EntityFrameworkCore;

//namespace RaunstrupAuth.Controllers
//{
//    public class MedarbejderController : Controller
//    {

//        private readonly ApplicationDbContext _context;
//        public MedarbejderController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Medarbejder
//        public async Task<IActionResult> Index()
//        {
//            var ApplicationDbContext = _context.medarbejder.Include(m => m.A);
//            return View(await ApplicationDbContext.ToListAsync());

            
           

//        }

//        // GET: Medarbejder/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var Medarbejder = await _context.medarbejder.Include(m=> m.A)
//                .FirstOrDefaultAsync(m => m.MID == id);
//            if (Medarbejder == null)
//            {
//                return NotFound();
//            }

//            return View(Medarbejder);
//        }

//        // GET: Materialer/Create
//        public IActionResult Create()
//        {
//            //ViewData["Vejnavn"] = new SelectList(_context.Set<Adresse>(), "Vejnavn", "Vejnavn");
//            //ViewData["SpecialeNavn"] = new SelectList(_context.Set<Speciale>(), "SpecialeNavn", "SpecialeNavn");
//            PopulateMedarbejderDropDownList();
//            return View();
//        }



//        // POST: Materialer/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Mid,Navn,Tlf,Udd,Aid,Fudd")] Medarbejder m)
//        {
        
//            if (ModelState.IsValid)
//            {
                
    
//                //A.Byid = b.ByID;
//                //m.Spid = s.Spid;
//                //_context.Add(A);
//                //_context.Add(s);
//                _context.Add(m);
               
               
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//           ViewData["Aid"] = new SelectList(_context.Set<Medarbejder>(), "Aid", "Aid", m.Aid);
//            //ViewData["SpeciaelNavn"] = new SelectList(_context.Set<Medarbejder>(), "SpecialeNavn", "SpecialeNavn", s.SpecialeNavn);
//            PopulateMedarbejderDropDownList(m.Aid);
//            return View(m);
           

//        }
      


//        private void PopulateMedarbejderDropDownList(object ValgtMedarbejder = null)
//        {
//            var MedarbejderQuery = from d in _context.adresse
//                                   orderby d.Vejnavn
//                                   select d;
//            ViewBag.Aid= new SelectList(MedarbejderQuery.AsNoTracking(), "Aid", "Vejnavn", ValgtMedarbejder);

          
//        }

//        // GET: Materialer/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var medarbejder = await _context.medarbejder.FindAsync(id);
//            if (medarbejder == null)
//            {
//                return NotFound();
//            }
//            PopulateMedarbejderDropDownList();
//            return View(medarbejder);
//        }

//        // POST: Materialer/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Mid,Navn,Aid,Tlf,Udd,Fudd,Spid")] Medarbejder medarbejder)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(medarbejder);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    ModelState.AddModelError("", "Unable to save changes. " +
//                              "Try again, and if the problem persists, " +
//                             "see your system administrator.");
//                           return RedirectToAction(nameof(Index));
//                }
                
//            }
//            ViewData["Aid"] = new SelectList(_context.medarbejder, "Aid", "Aid", medarbejder.Aid);
          
//            return View(medarbejder);
//        }

      

//        // GET: Materialer/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var medarbejder = await _context.medarbejder.Include(k=> k.A)
//                .FirstOrDefaultAsync(m => m.MID == id);
//            if (medarbejder == null)
//            {
//                return NotFound();
//            }

//            return View(medarbejder);
//        }

      

//        // POST: Materialer/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var medarbejder = await _context.medarbejder.FindAsync(id);
//            _context.medarbejder.Remove(medarbejder);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

     

//        private bool MedarbejderExists(int id)
//        {
//            return _context.medarbejder.Any(e => e.MID == id);
//        }


     













//        //    public  ActionResult PrintAllReport()
//        //        {
//        //             return new RotativaCore.ActionAsPdf    ("Index", new { _context.Medarbejder, FileName = "test.pdf" });

//        //        }
//        //        public ActionResult IndexById(int id)
//        //        {
//        //            var medarbejder = _context.Medarbejder.Where(e=> e.MID == id).First();
//        //            return View(medarbejder);
//        //        }
//        //        public ActionResult PrintSalarySlip(int id)
//        //        {
//        //            var report = new RotativaCore.ActionAsPdf("IndexById", new { ID = id });
//        //            return report;
//        //        }
//    }
//}
