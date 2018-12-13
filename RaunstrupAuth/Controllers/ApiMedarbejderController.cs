using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaunstrupAuth.Models;
using RaunstrupAuth.Data;

namespace RaunstrupAuth.Controllers
{
    //api/apimedarbejder
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMedarbejderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiMedarbejderController(ApplicationDbContext context)
        {
            _context = context;

            if (_context.Medarbejder.Count() == 0)
            {
                _context.Medarbejder.Add(new Medarbejder { Navn = "Item2" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Medarbejder>> GetAll()
        {
            return _context.Medarbejder.ToList();
        }

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
    }
}