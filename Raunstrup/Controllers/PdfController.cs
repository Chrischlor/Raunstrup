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

namespace Raunstrup.Controllers
{
    public class PdfController : Controller
    {
        private IConverter _converter;

        public PdfController(IConverter converter)
        {
            _converter = converter;
        }


        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\Users\Edb\Documents"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                HtmlContent = @"C:\Users\Edb\Documents\GitHub\Raunstrup\Raunstrup\Views\Medarbejders\Index.cshtml".ToString(),
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



        //public IActionResult Convert()
        //{
        //    var reinstdbContext = _context.Medarbejder.Include(m => m.A).Include(m => m.Sp);

        //    SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
        //    SelectPdf.PdfDocument doc = converter.ConvertUrl(@"C:\Users\Edb\Documents\GitHub\Raunstrup\Raunstrup\Views\Medarbejders\Index.cshtml");
        //    doc.Save("hej.pdf");
        //    doc.Close();

        //    return View(reinstdbContext);
        //}


    }
}

