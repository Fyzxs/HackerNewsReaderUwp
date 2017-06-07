using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.Screens.MainPageHotel {
    public class MainPageConcierge
    {
        public interface IElevator
        {
            void DisplayItem(Item body);
            void DisplayItems(Items items);
        }
        private readonly HackerNewsAccess _hackerNewsAccess;
        private readonly IElevator _elevator;
        
        public MainPageConcierge(IElevator elevator, HackerNewsAccess hackerNewsAccess)
        {
            _elevator = elevator;
            _hackerNewsAccess = hackerNewsAccess;
        }

        public async Task LoadItems() => _elevator.DisplayItems((await _hackerNewsAccess.TopStories()).Body());

        public async Task LoadItem(ItemId itemId) => _elevator.DisplayItem((await _hackerNewsAccess.Item(itemId)).Body());
    }
}