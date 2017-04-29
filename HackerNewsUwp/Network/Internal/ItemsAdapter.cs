using System.Net.Http;
using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemsAdapter : INetworkAdapter<Items>
    {
        public Items FromRawContent(string rawContent)
        {
            ItemId[] result = JsonConvert.DeserializeObject<ItemId[]>(rawContent);

            return new Items(result);
        }
    }
}