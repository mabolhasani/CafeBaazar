using Newtonsoft.Json;
using System;

namespace CafeBaazar.Models
{
    public class InappPurchaseResult
    {
        [JsonProperty("consumptionState")]
        public bool ConsumptionState { get; set; }

        [JsonProperty("purchaseState")]
        public bool PurchaseState { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("developerPayload")]
        public string DeveloperPayload { get; set; }

        [JsonProperty("purchaseTime")]
        private long PurchaseEpoch { get; set; }

        //TODO: use DateTime.UnixEpoch when .net standard 2.1 released
        public DateTime PurchaseDateUtc => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(PurchaseEpoch);
    }
}
