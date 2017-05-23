using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemIdAdapter : INetworkAdapter<ItemId>
    {
        public ItemId FromRawContent(string rawContent)
        {
            return new ItemId(JsonConvert.DeserializeObject<ItemIdJson>(rawContent).Id);
        }
    }
}