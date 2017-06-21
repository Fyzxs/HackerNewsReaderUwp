using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    internal class AuthorJson
    {
        [JsonProperty("by")]
        public string Author { get; set; }
    }
}