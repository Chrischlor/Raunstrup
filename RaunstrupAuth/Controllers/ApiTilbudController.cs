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
using DinkToPdf.EventDefinitions;


namespace RaunstrupAuth.Controllers
{   //api/apitilbud
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTilbudController : ControllerBase
    {   
        private ApplicationDbContext _context;
        private IConverter _converter;
        //Dependency injection
        public ApiTilbudController (ApplicationDbContext context, IConverter converter)
        {

            _context = context;
            _converter = converter;
           
        }

        //Her bliver Pdf genereret
        [HttpGet]
        public ActionResult CreatePDF()
        {

            //Konfiguration af pdf fil
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };


            var objectSettings = new ObjectSettings

            {
                PagesCount = true,
                HtmlContent = PdfTilbud.Gethtmlstring(_context),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };



            //HtmlToPdfDocument klassen bliver initialiseret, hvor der bliver lavet konfiguration af pdf fil. 
            var pdf = new HtmlToPdfDocument()

            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },



            };


            // Imens filen bliver konverteret, så bliver der også skabt et byte array, som bliver opbevaret i file variablen 
            var file = _converter.Convert(pdf);
            //returnerer pdf filen i browseren
            return File(file, "application/pdf", "Tilbud.pdf");

        }
    }

}




