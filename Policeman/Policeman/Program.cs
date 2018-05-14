﻿using System;
using System.ServiceModel.PeerResolvers;
using Policeman.MessageFilter;

namespace Policeman
{
    class Program
    {
        private static MessageFilter.MessagesFilterClient _messageClient;
        private static string _username;

        static void Main()
        {
            _messageClient = new MessageFilter.MessagesFilterClient("BasicHttpBinding_IMessagesFilter");

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

                    MessageFilter.Message message = null;
                    
                    message = new UpdateMessage();
                    if (input != null && input.ToUpper() == "U")
                    {
                        message = new UpdateMessage();                  
                    }

                    if (input.ToUpper() == "S")
                    {
                        message = new ShotMessage();
                    }

                    if (input.ToUpper() == "W")
                    {
                        message = new WarningMessage();
                    }
                    message.Username = _username;
                    message.X = getRandomLocation();
                    message.Y = getRandomLocation();
                    _messageClient.ReceiveData(message);
                }
            }
        }

        private static int getRandomLocation()
        {
            Random rnd = new Random();
            return rnd.Next(-90, 90);
        }
    }
}
