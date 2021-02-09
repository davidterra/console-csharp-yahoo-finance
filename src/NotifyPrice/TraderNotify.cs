using System.Threading.Tasks;

namespace NotifyPrice
{
    public class TraderNotify : INotity
    {
        private readonly ISendEmail _sendEmail;
        public TraderNotify(ISendEmail sendEmail, Trader trader)
            => (_sendEmail, Trader) = (sendEmail, trader);

        public Trader Trader { get; }
        public async Task Fire(Stock stock)
        {
            var content = $"Notificando que {stock.Symbol} atingiu o valor de mercado de {stock.Price.ToString("C")} no dia {stock.Date.ToString("dd/MM/yyy")}.";

            EmailMessage emailMessage = new(Trader.Email, content);

            await _sendEmail.SendMessage(emailMessage);
        }
    }
}