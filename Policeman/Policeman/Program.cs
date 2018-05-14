using System;
using Policeman.MessageFilter;

namespace Policeman
{
    class Program
    {
        private static MessagesFilterClient _messageClient;
        private static string _username;

        static void Main()
        {
            _messageClient = new MessagesFilterClient("BasicHttpBinding_IMessagesFilter");

            Console.WriteLine("Please enter your name: ");
            Console.WriteLine("If you want to quit press Q");
            Console.WriteLine("");
            _username = Console.ReadLine();

            if (_username == null || _username.ToUpper() == "Q")
            {
                return;
            }

            bool authentificationSuccess = _messageClient.LogIn(_username);

            if (authentificationSuccess)
            {
                while (true)
                {
                    Console.WriteLine("Q to quit");
                    Console.WriteLine("U to update");
                    Console.WriteLine("S to shot");
                    Console.WriteLine("W to warn");
                    var input = Console.ReadLine();
                    if (input != null && input.ToUpper() == "Q")
                        break;

                    Message message = new UpdateMessage();

                    if (input != null && input.ToUpper() == "U")
                    {
                        message = new UpdateMessage();                  
                    }

                    if (input != null && input.ToUpper() == "S")
                    {
                        message = new ShotMessage();
                    }

                    if (input != null && input.ToUpper() == "W")
                    {
                        message = new WarningMessage();
                    }
                    message.Username = _username;
                    message.X = GetRandomLocation(-90, 90);
                    message.Y = GetRandomLocation(-180, 180);
                    _messageClient.ReceiveData(message);
                }
            }
        }

        private static double GetRandomLocation(int maximum, int minimum)
        {
            Random rnd = new Random();
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
