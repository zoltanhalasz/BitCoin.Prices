using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using BitCoin.Prices.Models;

namespace BitCoin.Prices.Repository
{
    public class PricesRepository : IPricesRepository, IService
    {
        private readonly PricesContext _db;

        public PricesRepository(PricesContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Prices> GetPricess(int ModuleId)
        {
            return _db.Prices.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Prices GetPrices(int PricesId)
        {
            return _db.Prices.Find(PricesId);
        }

        public Models.Prices AddPrices(Models.Prices Prices)
        {
            _db.Prices.Add(Prices);
            _db.SaveChanges();
            return Prices;
        }

        public Models.Prices UpdatePrices(Models.Prices Prices)
        {
            _db.Entry(Prices).State = EntityState.Modified;
            _db.SaveChanges();
            return Prices;
        }

        public void DeletePrices(int PricesId)
        {
            Models.Prices Prices = _db.Prices.Find(PricesId);
            _db.Prices.Remove(Prices);
            _db.SaveChanges();
        }
    }
}
