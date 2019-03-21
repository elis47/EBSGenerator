using Newtonsoft.Json;

namespace EBSGenerator
{
    internal class Option
    {
        [JsonIgnore]
        public string Field { get; set; }

        [JsonIgnore]
        public string Op { get; set; }

        [JsonIgnore]
        public string Value { get; set; }

        [JsonProperty("Option")]
        public string Display => Field + "," + Op + "," + Value;
    }
}
