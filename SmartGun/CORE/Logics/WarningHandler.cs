using System;
using CORE.Interfaces;
using MessagesLibrary;

namespace CORE.Logics
{
    internal class WarningHandler : IWarningHandler
    {
        public void Handle(WarningMessage message)
        {
            AddWarningToDispatcher();
        }

        private void AddWarningToDispatcher()
        {
            Console.WriteLine("TODO add allert to HTML here!!!");
            //TODO add allert to HTML here!!! 
        }
    }
}