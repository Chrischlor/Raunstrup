using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup.Models;
using RotativaCore;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EvoPdf;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SelectPdf;
using System.Text;

namespace Raunstrup.Controllers
{
   public class MedarbejdersController: Controller
    {
        
        public readonly reinstdbContext _context;

        public MedarbejdersController(reinstdbContext context)
        {
            _context = context;
        }

      

        // GET: Medarbejders
        public async Task<IActionResult> Index()
        {
            var reinstdbContext = _context.Medarbejder.Include(m => m.A).Include(m => m.Sp);
            return View(await reinstdbContext.ToListAsync());
        }

        // GET: Medarbejders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejder = await _context.Medarbejder
                .Include(m => m.A)
                .Include(m => m.Sp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            return View(medarbejder);
        }

        // GET: Medarbejders/Create
        public IActionResult Create()
        {
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid");
            ViewData["Spid"] = new SelectList(_context.Speciale, "Spid", "Spid");
            return View();
        }

        // POST: Medarbejders/Create
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
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", medarbejder.Aid);
            ViewData["Spid"] = new SelectList(_context.Speciale, "Spid", "Spid", medarbejder.Spid);
            return View(medarbejder);
        }

        // GET: Medarbejders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejder = await _context.Medarbejder.FindAsync(id);
            if (medarbejder == null)
            {
                return NotFound();
            }
            ViewData["Aid"] = new SelectList(_context.Adresse, "Aid", "Aid", medarbejder.Aid);
            ViewData["Spid"] = new SelectList(_context.Speciale, "Spid", "Spid", medarbejder.Spid);
            return View(medarbejder);
        }

        // POST: Medarbejders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mid,Navn,Aid,Tlf,Udd,Fudd,Spid")] Medarbejder medarbejder)
        {
            if (id == medarbejder.Mid)
            {
                return NotFound();
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
                        return NotFound();
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

        // GET: Medarbejders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejder = await _context.Medarbejder
                .Include(m => m.A)
                .Include(m => m.Sp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            return View(medarbejder);
        }

        // POST: Medarbejders/Delete/5
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
       
         

          


            public ActionResult Convert( reinstdbContext _context)
            {
             reinstdbContext context = _context;
            
            //var report = new ActionAsPdf("Index");
            //return report;
            
            ////System.IO.File.WriteAllText(, _context);
            //string path = @"C:\Users\Edb\Documents\hej.txt";

            //// This text is added only once to the file.
            //if (!System.IO.File.Exists(path))
            //{
            //    // Create a file to write to.
            //    var createText = _context;
            //    System.IO.File.WriteAllText(path, createText );
            //}

            // This text is always added, making the file longer over time
            // if it is not deleted.
            //string appendText = "This is extra text" + Environment.NewLine;
            //System.IO.File.AppendAllText(path, appendText);

            // Open the file to read from.
            //string readText = System.IO.File.ReadAllText(path);
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertUrl("https://localhost:44311/Medarbejders");
            doc.Save("h.pdf");
            doc.Close();

            return View();
        }

        //public FileStreamResult SaveData(string _context)
        //{
        
        //    ////todo: add some data from your database into that string:
        //    //reinstdbContext string_with_your_data = _context;

        //    ////Build your stream
        //    //var byteArray = Encoding.ASCII.GetBytes(string_with_your_data.ToArray();
        //    //var stream = new MemoryStream(byteArray);
           
        //    ////Returns a file that will match your value passed in (ie TestID2.txt)
        //    //return File(stream, "text/plain", String.Format("luder.txt", _context));
            
        //}




    }
}




