
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace NotifyPrice
{
    public class YahooFinanceService
    {
        private readonly bool _ignoreEmptyRows;

        public YahooFinanceService(bool ignoreEmptyRows) => this._ignoreEmptyRows = ignoreEmptyRows;
        public async Task<IEnumerable<YahooFinanceApi.Candle>> GetCandle(DateTime start, DateTime end, string equity)
        {
            Yahoo.IgnoreEmptyRows = _ignoreEmptyRows;

            return await Yahoo.GetHistoricalAsync(equity, start, end);

        }

        public async Task<IEnumerable<YahooFinanceApi.Candle>> GetCandles(DateTime start, DateTime end, string[] equities)
        {
            var ticks = new List<YahooFinanceApi.Candle>();

            for (int i = 0; i < equities.Length; i++)
                ticks.AddRange(await GetCandle(start, end, equities[i]));

            return ticks;
        }
    }
}