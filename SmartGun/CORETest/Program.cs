using System;
using CORE;
using PointOfContact;
using MessagesLibrary;

namespace CORETest
{
    class Program
    {
        static void Main()
        {
            var core = new CoreService();
            core.HandleWarning(new WarningMessage(2, 2, "Bane"));
            core.HandleWarning(new WarningMessage(3, 4.1, "Cane"));
            core.HandleWarning(new WarningMessage(5.2, 2.5, "John"));
            core.HandleShot(new ShotMessage(2, 2, "Aane"));
            Console.ReadKey();
        }
    }
}
