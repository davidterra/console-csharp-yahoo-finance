using System.Threading.Tasks;

namespace NotifyPrice
{
    class Program
    {
        static async Task Main()
        {
            var stockConfig = StockConfig.FromJson();

            var stockMarketFacade = new StockMarketFacade(stockConfig);
            var corrier = new Courrier();
            var StockMarketService = new StockMarketService(stockMarketFacade, corrier);

            await StockMarketService.Monitoring();


        }



    }
}
