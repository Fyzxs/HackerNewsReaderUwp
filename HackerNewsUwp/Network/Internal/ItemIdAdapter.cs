using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemIdAdapter : INetworkAdapter<ItemId>
    {
        public ItemId FromRawContent(string rawContent)
        {
            long? rawItemId = JsonConvert.DeserializeObject<ItemIdJson>(rawContent).Id;
            return rawItemId.HasValue
                ? new ItemId(rawItemId.Value)
                : ItemId.NullItemId;
        }
    }
}