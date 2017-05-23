using HackerNewsUwp.Network;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Screens.MainView
{
    public class MainPageElevator
    {
        private readonly IMainPageView _mainPageView;

        public interface IMainPageView
        {
            ISetText Title();
            ISetText Count();
        }

        public MainPageElevator(IMainPageView mainPageView) => _mainPageView = mainPageView;

        public void DisplayTitle(string title) => _mainPageView.Title().Text = title;

        public void DisplayItems(Items items) => _mainPageView.Count().Text = $"{items.Count()}";
    }
}
