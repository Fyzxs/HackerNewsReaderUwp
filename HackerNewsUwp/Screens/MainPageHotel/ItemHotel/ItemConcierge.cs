using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.Screens.MainPageHotel.ItemHotel
{
    public class ItemConcierge
    {
        public interface IItemElevator
        {
            void Update(Item item);
        }

        private readonly IItemElevator _itemElevator;

        public ItemConcierge(IItemElevator itemElevator) => _itemElevator = itemElevator;

        public async Task Load(ItemId itemId)
        {
            Response<Item> response = await new HackerNewsAccess().Item(itemId);
            Item item = response.Body();
            _itemElevator.Update(item);
        }
    }
}
