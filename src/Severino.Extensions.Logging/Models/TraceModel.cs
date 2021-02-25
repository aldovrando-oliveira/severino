using Newtonsoft.Json;

namespace Severino.Extensions.Logging.Models
{
    public sealed class TraceModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}