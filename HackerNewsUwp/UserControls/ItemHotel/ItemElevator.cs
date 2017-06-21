using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.UserControls.ItemHotel
{
    public class ItemElevator
    {
        private readonly ItemId _itemId;
        private readonly ItemConcierge.IConcierge _conierge;
        private readonly IHackerNewsAccess _hackerNewwsAccess;

        public ItemElevator(ItemId itemId, ItemConcierge.IConcierge conierge, IHackerNewsAccess hackerNewwsAccess)
        {

            _itemId = itemId;
            _conierge = conierge;
            _hackerNewwsAccess = hackerNewwsAccess;
        }
        public interface IRoom
        {
            ISetText Title();
            ISetText Author();
        }

        public async void Load(IRoom room)
        {
            Item item = await _conierge.Load(_itemId, _hackerNewwsAccess);

            item.TitleInto(room.Title());
            item.AuthorInto(room.Author());
        }
    }
}