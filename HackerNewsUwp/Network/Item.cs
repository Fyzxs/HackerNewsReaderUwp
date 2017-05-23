using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Network
{
    public class Item
    {
        private readonly ItemId _itemId;
        private readonly Title _title;

        public Item(ItemId itemId, Title title)
        {
            _itemId = itemId;
            _title = title;
        }

        public void TitleInto(ISetText item)
        {
            _title.TitleInto(item);

        }
    }
}