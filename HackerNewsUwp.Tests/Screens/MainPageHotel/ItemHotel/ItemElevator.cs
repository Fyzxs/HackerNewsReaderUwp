using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    public partial class ItemElevatorTests
    {
        public class ItemElevator : ItemConcierge.IItemElevator
        {
            public interface IItemView
            {
                ISetText Title();
            }

            private readonly ItemConcierge _concierge;
            private readonly IItemView _itemView;

            public ItemElevator(IItemView itemView)
            {
                _itemView = itemView;
                _concierge = new ItemConcierge(this);
            }

            public async Task Load(ItemId itemId)
            {
                await _concierge.Load(itemId);
            }

            public void Update(Item item)
            {
                item.TitleInto(_itemView.Title());
            }
        }

    }

}
