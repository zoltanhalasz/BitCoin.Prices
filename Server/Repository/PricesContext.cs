using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using BitCoin.Prices.Models;

namespace BitCoin.Prices.Repository
{
    public class PricesContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Prices> Prices { get; set; }

        public PricesContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
