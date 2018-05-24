using CORE.Interfaces;
using MessagesLibrary;

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
            HTMLTableGenerator.AddRow(message);
        }
    }
}