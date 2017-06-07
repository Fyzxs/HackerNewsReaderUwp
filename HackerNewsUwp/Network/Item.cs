using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Network
{
    public class Item
    {
        private readonly ItemId _itemId;
        private readonly Title _title;
        private readonly Author _author;

        public Item(ItemId itemId, Title title, Author author)
        {
            _itemId = itemId;
            _title = title;
            _author = author;
        }

        public void TitleInto(ISetText item) => _title.Into(item);

        public void AuthorInto(ISetText item) => _author.Into(item);
    }
}