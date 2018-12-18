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
    public class PdfTilbud
    { //Statisk metode, der har database indhold som parameter
        public static string Gethtmlstring(ApplicationDbContext context)
        {
            //Her bliver der skabt en liste af typen Tilbud
            var Tilbud = context.Tilbud.ToList();
            
            //Stringbuilder klassen bliver initialiseret, hvor datatabellen bliver kreeret ved hjælp af stringbuilder objektet.
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Udskrivning af Tilbud</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Tid</th>
                                        <th>Projekttitle</th>
                                        <th>Startdato</th>
                                        <th>Deadline</th> 
                                        <th>Kid</th>
                                        <th>Rid</th>
                                        
                                             
                                    </tr>");
            //Loop, der sørger for at indsætte alle tilbud i Tilbudslisten.
            foreach (var tb in Tilbud)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", tb.Tid, tb.Projekttitle,tb.Startdato, tb.Deadline, tb.Kid,tb.Rid);
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

