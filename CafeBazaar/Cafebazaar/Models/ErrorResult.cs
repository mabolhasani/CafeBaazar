using Newtonsoft.Json;

namespace Cafebazaar.Models
{
    public class ErrorResult
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
