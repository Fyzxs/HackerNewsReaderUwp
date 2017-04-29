using System;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.Network
{
    public class Items
    {
        private readonly ItemId[] _itemIds;

        public Items(ItemId[] itemIds)
        {
            _itemIds = itemIds;
            if (itemIds == null)
            {
                throw new ArgumentNullException();
            }
        }
        public int Count()
        {
            return _itemIds.Length;
        }
    }
}