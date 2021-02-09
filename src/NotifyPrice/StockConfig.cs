using System.IO;
using System.Text.Json;

namespace NotifyPrice
{
    public class StockConfig
    {
        public bool IgnoreEmptyRows { get; set; }

        public static StockConfig FromJson()
        {
            var json = File.ReadAllText("AppSettings.json");
            return JsonSerializer.Deserialize<StockConfig>(json);
        }

    }
}