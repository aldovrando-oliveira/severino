using System.Diagnostics;
using Newtonsoft.Json;

namespace Severino.Extensions.Logging.Models
{
    public class ApiLogModel
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("trace")]
        public Trace Trace { get; set; }

        [JsonProperty("http")]
        public HttpModel Http { get; set; }

    }
}