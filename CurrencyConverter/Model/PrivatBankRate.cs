using System.Collections.Generic;
using Newtonsoft.Json;

namespace CurrencyConverter.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class PrivatBankRate
    {
        [JsonProperty(PropertyName = "ccy")]
        public string ccy { get; set; }

        [JsonProperty(PropertyName = "base_ccy")]
        public string base_ccy { get; set; }

        [JsonProperty(PropertyName = "buy")]
        public double buy { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public double sale { get; set; }
    }
}
