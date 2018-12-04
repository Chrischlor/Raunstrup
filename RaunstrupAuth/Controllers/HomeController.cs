using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaunstrupAuth.Models;

namespace RaunstrupAuth.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
            OnPost();
            
        }
        public async Task OnPost()
        {
            Email e = new Email();
            using (var smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtp.PickupDirectoryLocation = "Runebjepsen@gmail.com";
                var msg = new MailMessage
                {
                    Body = e.Besked,
                    Subject = e.Emne,
                    From = new MailAddress(e.Mail)

                };
                msg.To.Add(e.Navn);
                await smtp.SendMailAsync(msg);


            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
  
}
