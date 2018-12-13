using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using RaunstrupAuth.Models;
using RaunstrupAuth.Data;
using System.Text;

namespace RaunstrupAuth.Models
{
    public class PdfTemplate
    {
        public static string GetHTMLString(ApplicationDbContext context)
        {

            var medarbejder = context.Medarbejder.ToList();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Mid</th>
                                        <th>Navn</th>
                                        <th>Aid</th>
                                        <th>Tlf</th>
                                        <th>Udd</th>
                                        <th>Fudd</th>
                                        <th>Spid</th>
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
    

