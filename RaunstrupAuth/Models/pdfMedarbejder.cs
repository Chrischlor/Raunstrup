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
    public class pdfMedarbejder
    {
        
        //Statisk metode, der har database indhold som parameter
        public static string Gethtmlstring(ApplicationDbContext context)
        {
            //Her bliver der skabt en liste af typen medarbejder
            var medarbejder = context.Medarbejder.ToList();
            
            //Stringbuilder klassen bliver initialiseret, hvor datatabellen bliver kreeret ved hjælp af stringbuilder objektet.
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                            <div class='header'><h1>Udskrivning af Medarbejderne</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Mid</th>
                                        <th>Navn</th>
                                        <th>Adresseid</th>
                                        <th>Tlf</th>
                                        <th>Udd</th>
                                        <th>Fudd</th>
                                        <th>Spid</th>
                                    </tr>");
            //Loop, der sørger for at indsætte alle medarbejderne i medarbejderlisten.
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
            //objektet bliver konverteret til en string, som efterfølgende bliver returneret
            return sb.ToString();
        }
    }
}

