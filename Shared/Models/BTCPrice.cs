using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;
using Newtonsoft.Json;

namespace BitCoin.Prices.Models
{
    [Table("BTCPrice")]
    public class BTCPrice : IAuditable
    {
        public int Id { get; set; }
        public string RefreshDate { get; set; }
        public decimal PriceUsd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    public class Quotation
    {
        [JsonProperty("Realtime Currency Exchange Rate")]
        public QuoteDetail Detail { get; set; }
    }

    public class QuoteDetail
    {
        [JsonProperty("5. Exchange Rate")]
        public decimal ExchangeRate { get; set; }

        [JsonProperty("6. Last Refreshed")]
        public string RefreshDate { get; set; }
    }
}
