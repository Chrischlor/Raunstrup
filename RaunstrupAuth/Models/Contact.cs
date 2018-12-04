using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RaunstrupAuth.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

namespace RaunstrupAuth.Models
{
    public class Contact : PageModel
    {
        [BindProperty]
        public string Navn { get; set; }
        [BindProperty]
        public string Mail { get; set; }
        [BindProperty]
        public string Emne { get; set; }
        [BindProperty]
        public string Besked { get; set; } = "";


        public string PostedMessage { get; set; } = "";


        public void OnGet(int id)
        {
            ViewData["PostedMessage"] = "Your Message has been sent [ViewData]";
            PostedMessage = "Your Message has been sent [property]";
        }




        //public async Task SendMail(string name, string email, string Emne, string messageBody)
        //{
        //    using (var smtp = new SmtpClient())
        //    {
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        //        smtp.PickupDirectoryLocation = "madsrynord@live.dk";
        //        var msg = new MailMessage
        //        {
        //            Body = messageBody,
        //            Subject = Emne,
        //            From = new MailAddress(email)

        //        };
        //        msg.To.Add(name);
        //        await smtp.SendMailAsync(msg);
        //    }
        //}
    }
    
}
