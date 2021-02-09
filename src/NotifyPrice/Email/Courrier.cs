using System;
using System.Threading.Tasks;

namespace NotifyPrice
{
    public class Courrier : ISendEmail
    {
        public async Task SendMessage(EmailMessage message)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Enviado e-mail to {message.To} com {message.Content} ");
        }
    }
}