using System.Collections.Generic;
using BitCoin.Prices.Models;

namespace BitCoin.Prices.Repository
{
    public interface IPricesRepository
    {
        IEnumerable<Models.Prices> GetPricess(int ModuleId);
        Models.Prices GetPrices(int PricesId);
        Models.Prices AddPrices(Models.Prices Prices);
        Models.Prices UpdatePrices(Models.Prices Prices);
        void DeletePrices(int PricesId);
    }
}
