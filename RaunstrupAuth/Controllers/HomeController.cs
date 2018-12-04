using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaunstrupAuth.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            string navn = contact.Navn;
            string mail = contact.Mail;
            string emne = contact.Emne;
            string besked = contact.Besked;

            SendMail(navn, mail, emne, besked);
            return View();

        }
        public void SendMail(string name, string email, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(name, email)); 
            message.To.Add(new MailboxAddress("Mads", "testermgr@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = messageBody + " sendt fra: " + email
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("testermgr@gmail.com", "1234WEOW");
                client.Send(message);
                client.Disconnect(true);

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
