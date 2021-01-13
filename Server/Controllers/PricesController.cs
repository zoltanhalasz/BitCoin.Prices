using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using BitCoin.Prices.Models;
using BitCoin.Prices.Repository;

namespace BitCoin.Prices.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class PricesController : Controller
    {
        private readonly IPricesRepository _PricesRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public PricesController(IPricesRepository PricesRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _PricesRepository = PricesRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Prices> Get(string moduleid)
        {
            return _PricesRepository.GetPricess(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Prices Get(int id)
        {
            Models.Prices Prices = _PricesRepository.GetPrices(id);
            if (Prices != null && Prices.ModuleId != _entityId)
            {
                Prices = null;
            }
            return Prices;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Prices Post([FromBody] Models.Prices Prices)
        {
            if (ModelState.IsValid && Prices.ModuleId == _entityId)
            {
                Prices = _PricesRepository.AddPrices(Prices);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Prices Added {Prices}", Prices);
            }
            return Prices;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Prices Put(int id, [FromBody] Models.Prices Prices)
        {
            if (ModelState.IsValid && Prices.ModuleId == _entityId)
            {
                Prices = _PricesRepository.UpdatePrices(Prices);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Prices Updated {Prices}", Prices);
            }
            return Prices;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Prices Prices = _PricesRepository.GetPrices(id);
            if (Prices != null && Prices.ModuleId == _entityId)
            {
                _PricesRepository.DeletePrices(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Prices Deleted {PricesId}", id);
            }
        }
    }
}
