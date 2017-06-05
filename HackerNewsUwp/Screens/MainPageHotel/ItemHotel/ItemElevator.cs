using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Screens.MainPageHotel.ItemHotel
{
        public class ItemElevator : ItemConcierge.IItemElevator
        {
            public interface IItemView
            {
                ISetText Title();
                void Loaded();
            }

            private readonly ItemConcierge _concierge;
            private readonly IItemView _itemView;

            public ItemElevator(IItemView itemView)
            {
                _itemView = itemView;
                _concierge = new ItemConcierge(this);
            }

            public void Load(ItemId itemId)
            {
                _concierge.Load(itemId);
            }

            public void Update(Item item)
            {
                item.TitleInto(_itemView.Title());
            }
        }
}
