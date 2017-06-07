using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    internal class AuthorJson
    {
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}