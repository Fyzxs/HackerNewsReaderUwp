using HackerNewsUwp.Network;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Screens.MainView
{
    public class MainPageBridge
    {
        private readonly IMainPageView _mainPageView;

        public interface IMainPageView
        {
            IText Title();
            IText Count();
        }

        public MainPageBridge(IMainPageView mainPageView) => _mainPageView = mainPageView;

        public void DisplayTitle(string title) => _mainPageView.Title().Text = title;

        public void DisplayItems(Items items) => _mainPageView.Count().Text = $"{items.Count()}";
    }
}
