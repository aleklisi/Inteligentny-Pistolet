using System;
using System.Web.UI.HtmlControls;
using CORE.Interfaces;
using MessagesLibrary;
using PointOfContact;

namespace CORE.Logics
{
    internal class WarningHandler : IWarningHandler
    {
        public void Handle(WarningMessage message)
        {
            AddWarningToDispatcher(message);
        }

        private void AddWarningToDispatcher(WarningMessage message)
        {
            Console.WriteLine("TODO add allert to HTML here!!!");
            //TODO add allert to HTML here!!! 
            HTMLTableService.AddColumn(message);
        }
    }
}