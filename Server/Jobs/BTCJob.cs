using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoin.Prices.Server.Jobs
{
    public class BTCJob : HostedServiceBase
    {
     
        public BTCJob(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory) { }

        public override string ExecuteJob(IServiceProvider provider)
        {
            string log = "<br />Retrieve BTC price at " + DateTime.Now.ToShortTimeString() + "<br />";
            return log;
        }   
    }
}
