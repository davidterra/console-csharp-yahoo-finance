using System;
using System.Collections.Generic;

namespace NotifyPrice
{
    public interface IStockMarketFacade
    {
        IAsyncEnumerable<Quote> GetQuotes(DateTime start, DateTime end, string[] equities);
    }
}