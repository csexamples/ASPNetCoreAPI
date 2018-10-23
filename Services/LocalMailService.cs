using System;
using System.Diagnostics;
using CityInfoAPI.Properties;

namespace CityInfoAPI.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];
        private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
