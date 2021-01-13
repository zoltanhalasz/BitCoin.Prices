using System.Collections.Generic;
using System.Threading.Tasks;
using BitCoin.Prices.Models;

namespace BitCoin.Prices.Services
{
    public interface IPricesService 
    {
        Task<List<Models.Prices>> GetPricessAsync(int ModuleId);

        Task<Models.Prices> GetPricesAsync(int PricesId, int ModuleId);

        Task<Models.Prices> AddPricesAsync(Models.Prices Prices);

        Task<Models.Prices> UpdatePricesAsync(Models.Prices Prices);

        Task DeletePricesAsync(int PricesId, int ModuleId);
    }
}
