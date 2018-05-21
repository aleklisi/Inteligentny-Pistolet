using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using MessagesLibrary;

namespace CORE.Logics
{
    public class HTMLTableService
    {
        private static string filename = @"C:\Users\Natalia\Documents\Inteligentny-Pistolet\SmartGun\Dispatcher\table.html";

        public static void AddColumn(Message message)
        {
            StringBuilder newRow = new StringBuilder();
            newRow.Append("<tr>");
            newRow.Append(Environment.NewLine);
            newRow.Append("<td>" + DateTime.Now.ToString("h:mm:ss tt") + "</td>");
            newRow.Append(Environment.NewLine);
            newRow.Append("<td>" + message.MessageType + "</td>");
            newRow.Append(Environment.NewLine);
            newRow.Append("<td>" + message.Username + "</td>");
            newRow.Append(Environment.NewLine);
            newRow.Append("<td>" + "https://www.google.pl/maps/@" + 
                          message.Y + "," + message.X+ ",13z" + "</td>");
        
            newRow.Append(Environment.NewLine);
            newRow.Append("</tr>");
            newRow.Append(Environment.NewLine);

            File.AppendAllText(filename, newRow + Environment.NewLine);
        }
    }
}