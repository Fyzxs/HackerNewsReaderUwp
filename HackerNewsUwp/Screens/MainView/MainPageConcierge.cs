using System.Threading.Tasks;
using HackerNewsUwp.Network;

namespace HackerNewsUwp.Screens.MainView {
    public class MainPageMediator
    {
        private readonly HackerNewsAccess _hackerNewsAccess;
        private readonly MainPageBridge _mainPageBridge;
        
        public MainPageMediator(MainPageBridge mainPageBridge, HackerNewsAccess hackerNewsAccess)
        {
            _mainPageBridge = mainPageBridge;
            _hackerNewsAccess = hackerNewsAccess;
        }

        private void DisplayItems(Items items) => _mainPageBridge.DisplayItems(items);
        public async Task LoadItems() => DisplayItems((await _hackerNewsAccess.TopStories()).Body());
    }
}