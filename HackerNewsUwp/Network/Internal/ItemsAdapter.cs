using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemsAdapter : INetworkAdapter<Items>
    {
        public Items FromRawContent(string rawContent) => new Items(ItemIdList(ParsedJson(rawContent)));

        private static IEnumerable<ItemIdJson> ParsedJson(string rawContent) => JsonConvert.DeserializeObject<long[]>(rawContent).Select(id => new ItemIdJson() { Id = id}).ToList();

        private static List<ItemId> ItemIdList(IEnumerable<ItemIdJson> result) => result.Select(itemIdJson => new ItemId(id: itemIdJson.Id)).ToList();
    }
}