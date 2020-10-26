using System;
namespace HeroUI
{
    public class MessagingService : IMessagingService
    {
        public void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input! Please choose a valid option.");
        }
    }
}