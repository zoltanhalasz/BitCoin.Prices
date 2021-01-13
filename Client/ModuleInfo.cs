using Oqtane.Models;
using Oqtane.Modules;

namespace BitCoin.Prices
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Prices",
            Description = "Prices",
            Version = "1.0.0",
            ServerManagerType = "BitCoin.Prices.Manager.PricesManager, BitCoin.Prices.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "BitCoin.Prices.Shared.Oqtane"
        };
    }
}
