using Newtonsoft.Json;

namespace CurrencyConverter.Model.Parser
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]

    public class NBURate
    {
        [JsonProperty(PropertyName = "r030")]
        public int r030 { get; set; }

        [JsonProperty(PropertyName = "txt")]
        public string txt { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public float rate { get; set; }

        [JsonProperty(PropertyName = "cc")]
        public string cc { get; set; }

        [JsonProperty(PropertyName = "exchangedate ")]
        public string exchangedate { get; set; }
    }
}
