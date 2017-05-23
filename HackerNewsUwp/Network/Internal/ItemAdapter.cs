using System;
using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemAdapter : INetworkAdapter<Item>
    {
        public Item FromRawContent(string rawContent)
        {
            ItemId itemId = new ItemIdAdapter().FromRawContent(rawContent);
            Title title = new TitleAdapter().FromRawContent(rawContent);
            return new Item(itemId: itemId, title: title);
        }
    }
}