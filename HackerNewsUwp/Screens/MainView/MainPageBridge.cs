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

        public MainPageBridge(IMainPageView mainPageView)
        {
            _mainPageView = mainPageView;
        }

        public void DisplayTitle(string title)
        {
            IText textBox = _mainPageView.Title();
            textBox.Text = title;
        }
        
        public void DisplayItems(Items items)
        {
            IText item = _mainPageView.Count();
            item.Text = $"{items.Count()}";
        }
    }
}
