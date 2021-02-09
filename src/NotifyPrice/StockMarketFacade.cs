using System;
using System.Collections.Generic;

namespace NotifyPrice
{

    public class StockMarketFacade : IStockMarketFacade
    {
        private readonly StockConfig _strockConfig;

        public StockMarketFacade(StockConfig strockConfig) => this._strockConfig = strockConfig;
        public async IAsyncEnumerable<Quote> GetQuotes(DateTime start, DateTime end, string[] equities)
        {
            var yahoo = new YahooFinanceService(_strockConfig.IgnoreEmptyRows);

            var quotes = await yahoo.GetCandles(start, end, equities);

            foreach (var quote in quotes)
                yield return ToQuote(quote);
        }

        private Quote ToQuote(YahooFinanceApi.Candle candle)
            => new Quote(candle.DateTime, candle.Open, candle.High, candle.Low, candle.Close,
                        candle.Volume, candle.AdjustedClose);
    }
}