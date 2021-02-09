using System.Threading.Tasks;

namespace NotifyPrice
{
    public interface INotity
    {
        Trader Trader { get; }
        Task Fire(Stock stock);
    }
}