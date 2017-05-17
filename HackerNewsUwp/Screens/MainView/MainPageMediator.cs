using System.Threading.Tasks;
using HackerNewsUwp.Network;
using HackerNewsUwp.Screens.MainView;

namespace HackerNewsUwp.Tests.Screens.MainPage {
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