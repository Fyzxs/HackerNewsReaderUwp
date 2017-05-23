using System;
using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    internal class ItemAdapter : INetworkAdapter<Item>
    {
        public Item FromRawContent(string rawContent)
        {
            throw new NotImplementedException();
        }
    }
}