namespace NotifyPrice
{
    public class StockQuote : Stock
    {
        public StockQuote(string symbol, decimal price)
            : base(symbol, price) { }
    }
}