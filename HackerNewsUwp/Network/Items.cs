using System;
using System.Collections.Generic;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.Network
{
    public class Items
    {
        private readonly List<ItemId> _itemIds;

        public Items(List<ItemId> itemIds)
        {
            _itemIds = itemIds;
            if (itemIds == null)
            {
                throw new ArgumentNullException();
            }
        }
        public int Count() => _itemIds.Count;
    }
}