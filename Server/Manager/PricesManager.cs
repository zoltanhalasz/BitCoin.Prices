using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using BitCoin.Prices.Models;
using BitCoin.Prices.Repository;

namespace BitCoin.Prices.Manager
{
    public class PricesManager : IInstallable, IPortable
    {
        private IPricesRepository _PricesRepository;
        private ISqlRepository _sql;

        public PricesManager(IPricesRepository PricesRepository, ISqlRepository sql)
        {
            _PricesRepository = PricesRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "BitCoin.Prices." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "BitCoin.Prices.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Prices> Pricess = _PricesRepository.GetPricess(module.ModuleId).ToList();
            if (Pricess != null)
            {
                content = JsonSerializer.Serialize(Pricess);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Prices> Pricess = null;
            if (!string.IsNullOrEmpty(content))
            {
                Pricess = JsonSerializer.Deserialize<List<Models.Prices>>(content);
            }
            if (Pricess != null)
            {
                foreach(var Prices in Pricess)
                {
                    _PricesRepository.AddPrices(new Models.Prices { ModuleId = module.ModuleId, Name = Prices.Name });
                }
            }
        }
    }
}