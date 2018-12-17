using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using RaunstrupAuth.Models;
using RaunstrupAuth.Data;
using System.Text;
using System.Linq;
using System.IO;


namespace RaunstrupAuth.Models
{
    public class pdftemplate
    {
        
      
        public static string Gethtmlstring(ApplicationDbContext context)
        {

            var medarbejder = context.Medarbejder.ToList();
            




            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>this is the generated pdf report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>id</th>
                                        <th>navn</th>
                                        <th>adresid</th>
                                        <th>telefon</th>
                                        <th>udd</th>
                                        <th>fudd</th>
                                        <th>spid</th>
                                    </tr>");

            foreach (var med in medarbejder)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>

                                  </tr>", med.Mid, med.Navn, med.Aid, med.Tlf, med.Udd, med.Fudd, med.Spid);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}

