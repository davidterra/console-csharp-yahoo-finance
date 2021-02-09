using System.Threading.Tasks;

namespace NotifyPrice
{
    public interface ISendEmail
    {
         Task SendMessage(EmailMessage message);
    }
}