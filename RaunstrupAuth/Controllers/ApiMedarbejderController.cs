using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaunstrupAuth.Models;
using RaunstrupAuth.Data;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;

namespace RaunstrupAuth.Controllers
{
    ////api/apimedarbejder
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMedarbejderController : Controller
    {
        private ApplicationDbContext _context;

        //public ApiMedarbejderController(ApplicationDbContext context)
        //{
        //    _context = context;

        //    if (_context.Medarbejder.Count() == 0)
        //    {
        //        _context.Medarbejder.Add(new Medarbejder { Navn = "Item2" });
        //        _context.SaveChanges();
        //    }
        //}

        //[HttpGet]
        //public ActionResult<List<Medarbejder>> GetAll()
        //{
        //    return _context.Medarbejder.ToList();
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Medarbejder> GetById(int id)
        //{
        //    var item = _context.Medarbejder.Find(id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}

        private IConverter _converter;

        public ApiMedarbejderController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        //[Route("api/[controller]")]
        public IActionResult CreatePDF(ApplicationDbContext context)
        {
            _context = context;
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\Users\Edb\Documents\PDFTEST\Employee_Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PdfTemplate.GetHTMLString(_context),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Successfully created PDF document.");
        }
    }
}
    
