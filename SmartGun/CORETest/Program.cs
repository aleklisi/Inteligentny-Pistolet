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
            core.HandleShot(new ShotMessage(2, 2, "Aane"));
            Console.ReadKey();
        }
    }
}
