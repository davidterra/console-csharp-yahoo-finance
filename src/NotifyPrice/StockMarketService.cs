using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotifyPrice
{
    public class StockMarketService
    {
        private readonly IStockMarketFacade _stockMarketFacede;
        private readonly ISendEmail _sendEmail;
        public StockMarketService(IStockMarketFacade stockMarketFacede, ISendEmail sendEmail)
            => (_stockMarketFacede, _sendEmail) = (stockMarketFacede, sendEmail);


        public async Task Monitoring()
        {
            var start = new DateTime(2021, 02, 01);
            var end = new DateTime(2021, 02, 05);

            var trader = new TraderNotify(_sendEmail, new Trader("test@test.it"));
            var trader2 = new TraderNotify(_sendEmail, new Trader("test2@test.it"));

            var stock = new StockQuote("AMZN", 0);

            stock.Subscribe(trader);
            stock.Subscribe(trader2);

            var quotes = _stockMarketFacede.GetQuotes(start, end, new string[] { "AMZN" });

            await foreach (var quote in quotes)
            {
                stock.Date = quote.Date;
                stock.Price = quote.AdjustedClose;                
            }

        }
    }
}