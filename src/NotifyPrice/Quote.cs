using System;

namespace NotifyPrice
{
    public record Quote(DateTime Date, decimal Open, decimal High, decimal Low, decimal Close, decimal Volume, decimal AdjustedClose);
    
}