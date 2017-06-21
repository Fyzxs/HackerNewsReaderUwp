using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using System.Threading.Tasks;

namespace HackerNewsUwp.UserControls.ItemHotel
{
    public class ItemConcierge : ItemConcierge.IConcierge
    {
        public interface IElevator
        {
        }
        public interface IConcierge
        {
            Task<Item> Load(ItemId itemId, IHackerNewsAccess hackerNewwsAccess);
        }

        public async Task<Item> Load(ItemId itemId, IHackerNewsAccess hackerNewwsAccess) => (await hackerNewwsAccess.Item(itemId)).Body();

    }
}