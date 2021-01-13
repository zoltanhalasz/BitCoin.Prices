using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using BitCoin.Prices.Models;

namespace BitCoin.Prices.Services
{
    public class PricesService : ServiceBase, IPricesService, IService
    {
        private readonly SiteState _siteState;

        public PricesService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "Prices");

        public async Task<List<Models.Prices>> GetPricessAsync(int ModuleId)
        {
            List<Models.Prices> Pricess = await GetJsonAsync<List<Models.Prices>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Pricess.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Prices> GetPricesAsync(int PricesId, int ModuleId)
        {
            return await GetJsonAsync<Models.Prices>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PricesId}", ModuleId));
        }

        public async Task<Models.Prices> AddPricesAsync(Models.Prices Prices)
        {
            return await PostJsonAsync<Models.Prices>(CreateAuthorizationPolicyUrl($"{Apiurl}", Prices.ModuleId), Prices);
        }

        public async Task<Models.Prices> UpdatePricesAsync(Models.Prices Prices)
        {
            return await PutJsonAsync<Models.Prices>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Prices.PricesId}", Prices.ModuleId), Prices);
        }

        public async Task DeletePricesAsync(int PricesId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PricesId}", ModuleId));
        }
    }
}
