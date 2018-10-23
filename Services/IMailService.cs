using System;

namespace CityInfoAPI.Properties
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
