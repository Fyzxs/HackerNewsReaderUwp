using System;
using System.Collections.Generic;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls.ItemHotel;

namespace HackerNewsUwp.Network
{
    public class Items
    {
        private readonly List<ItemId> _itemIds;

        public interface IItemIdConsumer
        {
            void ConsumeItemId(ItemId itemId);
        }

        public Items(List<ItemId> itemIds)
        {
            _itemIds = itemIds;
            if (itemIds == null)
            {
                throw new ArgumentNullException();
            }
        }
        public int Count() => _itemIds.Count;

        public void ProvideId(int index, IItemIdConsumer itemIdConsumer )
        {
            itemIdConsumer.ConsumeItemId(_itemIds[index]);
        }
    }
}