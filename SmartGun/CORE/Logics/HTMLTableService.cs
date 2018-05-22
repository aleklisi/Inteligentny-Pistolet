using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Database.Model;
using MessagesLibrary;

namespace CORE.Logics
{
    public class HTMLTableService
    {
        private static string filename = @"C:\Users\Natalia\Documents\Inteligentny-Pistolet\SmartGun\Dispatcher\table.html";

        public static void AddRow(Message message, List<Policeman> nearestPoliceman = null)
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
            String link = "https://www.google.pl/maps/@" + message.Y + "," + message.X + ",13z";
            newRow.Append("<td>" + "<a href = " + link+ " > " + link + " </a>" + "</td>");
            newRow.Append(Environment.NewLine);
            if (message.MessageType == MessageType.Warning)
            {
                newRow.Append("<td>" + " - " + "</td>");
            }
            else if (message.MessageType == MessageType.Shot)
            {
                if (nearestPoliceman == null)
                {
                    newRow.Append("<td>" + " 0 " + "</td>");
                }
                else
                {
                    foreach (var policeman in nearestPoliceman)
                    {
                        string linkToLocation = "https://www.google.pl/maps/@" + policeman.Y + "," + policeman.X + ",13z";
                        newRow.Append("<td>" + "<a href = " + link + " > " + policeman.Name + " </a>" + "</td>");
                        newRow.Append(Environment.NewLine);
                    }
                    
                }
            }      
            newRow.Append(Environment.NewLine);
            newRow.Append("</tr>");
            newRow.Append(Environment.NewLine);

            File.AppendAllText(filename, newRow + Environment.NewLine);
        }
    }
}