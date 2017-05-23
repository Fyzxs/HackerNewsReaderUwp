using System.Threading.Tasks;
using HackerNewsUwp.Network;

namespace HackerNewsUwp.Screens.MainView {
    public class MainPageConcierge
    {
        private readonly HackerNewsAccess _hackerNewsAccess;
        private readonly MainPageElevator _mainPageBridge;
        
        public MainPageConcierge(MainPageElevator mainPageBridge, HackerNewsAccess hackerNewsAccess)
        {
            _mainPageBridge = mainPageBridge;
            _hackerNewsAccess = hackerNewsAccess;
        }

        private void DisplayItems(Items items) => _mainPageBridge.DisplayItems(items);
        public async Task LoadItems() => DisplayItems((await _hackerNewsAccess.TopStories()).Body());

        public Task LoadItem(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}