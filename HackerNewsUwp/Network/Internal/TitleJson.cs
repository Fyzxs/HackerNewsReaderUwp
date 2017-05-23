using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    internal class TitleJson
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}