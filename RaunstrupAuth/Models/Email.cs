using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RaunstrupAuth.Models;
namespace RaunstrupAuth.Models
{
    public class Email
    {
        public string Navn { get; set; }

        public string Mail { get; set; }
        public string Emne { get; set; }
        public string Besked { get; set; }

        [BindProperty]
        public Email Contact { get; set; }


    }
}
