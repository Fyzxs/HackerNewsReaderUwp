using Newtonsoft.Json;
#pragma warning disable CS0649 //JSON Data Bag

namespace HackerNewsUwp.Network.Internal
{
    internal class ItemIdJson
    {
        [JsonProperty("id")] public long Id;
    }
}
