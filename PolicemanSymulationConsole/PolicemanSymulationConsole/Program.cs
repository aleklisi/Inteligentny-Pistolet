using System;
using System.ServiceModel;
using PolicemanSymulationConsole.ServiceReference1;

namespace PolicemanSymulationConsole
{
    class Program
    {
        private static ServiceReference1.IMessagesFilter channel;
        private static int failedlog = 0;

        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceReference1.MessagesFilterClient));
            ChannelFactory<ServiceReference1.IMessagesFilter> cf = new ChannelFactory<ServiceReference1
                .IMessagesFilter>("WSHttpBinding_IMessagesFilter");
            channel = cf.CreateChannel();

            char input = '0';

            ShowGreeting();
            input = System.Console.ReadKey().KeyChar;
            System.Console.WriteLine();

            if (input == 's' || input == 'S')
            {

                System.Console.WriteLine("Please put an username: ");
                string username = System.Console.ReadLine();
                if (username != null && username.Length > 4)
                {
                    channel.ReceiveData(generateMessage(username, MessageType.Update));
                }
                else
                {
                    System.Console.WriteLine("Username is too short");
                    input = 'q';
                }
            }

            while (input != 'q' && input != 'Q' && failedlog < 3)
            {
                string login = TryLogIn();
                if (channel.LogIn(login))
                {
                    System.Console.WriteLine("Sign in success");
                    channel.ReceiveData(new Message() { X = GetRandomNumber(0.0, 100.0), Y = GetRandomNumber(0.0, 100.0),
                        MessageType = MessageType.Update, Username = login });
                    while (input != 'q')
                    {
                        ShowMenuToSendMessage();
                        input = System.Console.ReadKey().KeyChar;
                        System.Console.WriteLine();
                        string messageCode = input.ToString().ToLower();
                        if (messageCode == "u")
                        {
                             channel.ReceiveData(generateMessage(login, MessageType.Update));
                        }
                        if (messageCode == "w")
                        {
                            channel.ReceiveData(generateMessage(login, MessageType.Warning));
                        }
                        if (messageCode == "s")
                        {
                            channel.ReceiveData(generateMessage(login, MessageType.Shot));
                        }
                        
                    }          
                }
                else
                {
                    System.Console.WriteLine("Access denied");
                    failedlog++;
                }
                System.Console.WriteLine("If you want to exit press q");
                input = System.Console.ReadKey().KeyChar;
                System.Console.WriteLine();
            }
            
        }

        private static String TryLogIn()
        {
            System.Console.WriteLine("To sign in put your login");
            string login = System.Console.ReadLine();
            return login;
        }

        private static void ShowGreeting()
        {
            System.Console.WriteLine("SmartGun System");
            System.Console.WriteLine("If you want to exit press q");
            System.Console.WriteLine("If you want to sign in press s");
            System.Console.WriteLine("If you want to log in press other key");

        }

        private static void ShowMenuToSendMessage()
        {
            System.Console.WriteLine("SmartGun Message System");
            System.Console.WriteLine("Warning Message press W");
            System.Console.WriteLine("Shot Message press S");
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private static Message generateMessage(string login, MessageType userMessageType)
        {
            return new Message()
            {
                X = GetRandomNumber(0.0, 100.0),
                Y = GetRandomNumber(0.0, 100.0),
                MessageType = userMessageType,
                Username = login
            };
         }

    }
}
