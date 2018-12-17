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
{
    ////api/apimedarbejder
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMedarbejderController : Controller
    {

        public ApplicationDbContext _context;
        public IConverter _converter;

        //Dependency injection
        public ApiMedarbejderController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
            //Hvis medarbejder ikke eksisterer, så tilføj navn
            if (_context.Medarbejder.Count() == 0)
            {
                _context.Medarbejder.Add(new Medarbejder { Navn = "Item2" });
                _context.SaveChanges();
            }
        }
        //Returnerer medarbejderne i json format
        [Route("api/Getall")]
        [HttpGet]
        public ActionResult<List<Medarbejder>> GetAll()
        {
            return _context.Medarbejder.ToList();
        }
        //Søger efter Den pågældende medarbejders id
        [HttpGet("{id}")]
        public ActionResult<Medarbejder> GetById(int id)
        {
            var item = _context.Medarbejder.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        

     
        //Her bliver Pdf genereret
        [HttpGet]
        public ActionResult CreatePDF()
        {

      

            
        var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                //Out = @"C:\Users\Edb\Documents\PDFTEST\test1.pdf"


            };


            var objectSettings = new ObjectSettings

            {
                PagesCount = true,
                HtmlContent = pdftemplate.Gethtmlstring(_context),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };


           






            var pdf = new HtmlToPdfDocument()

             {
                        GlobalSettings = globalSettings,
                        Objects = { objectSettings },



             };

           

            var file= _converter.Convert(pdf);

            return File(file, "application/pdf", "test.pdf" );

               }
            }

         }





