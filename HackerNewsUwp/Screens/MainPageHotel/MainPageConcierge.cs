using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.Screens.MainPageHotel {
    public class MainPageConcierge
    {
        public interface IElevator
        {
            void DisplayItems(Items items);
            void DisplayItem(Item body);
        }
        private readonly HackerNewsAccess _hackerNewsAccess;
        private readonly IElevator _elevator;
        
        public MainPageConcierge(IElevator elevator, HackerNewsAccess hackerNewsAccess)
        {
            _elevator = elevator;
            _hackerNewsAccess = hackerNewsAccess;
        }

        private void DisplayItems(Items items) => _elevator.DisplayItems(items);
        public async void LoadItems() => DisplayItems((await _hackerNewsAccess.TopStories()).Body());

        public async Task LoadItem(ItemId itemId)
        {
            Response<Item> response = await _hackerNewsAccess.Item(itemId);
            _elevator.DisplayItem(response.Body());
        }
    }
}