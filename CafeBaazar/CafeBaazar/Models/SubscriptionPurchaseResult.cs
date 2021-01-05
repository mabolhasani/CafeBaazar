using Newtonsoft.Json;
using System;

namespace CafeBaazar.Models
{
    public class SubscriptionPurchaseResult
    {
        [JsonProperty("initiationTimestampMsec")]
        private long InitiationTimestampMsec { get; set; }

        [JsonProperty("validUntilTimestampMsec")]
        private long ValidUntilTimestampMsec { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("autoRenewing")]
        public bool AutoRenewing { get; set; }

        //TODO: use DateTime.UnixEpoch when .net standard 2.1 released
        public DateTime InitiationDateUtc => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(InitiationTimestampMsec);

        public DateTime ValidUntilDateUtc => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ValidUntilTimestampMsec);
    }
}
