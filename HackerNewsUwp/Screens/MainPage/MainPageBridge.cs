using Windows.UI.Xaml.Controls;

namespace HackerNewsUwp.Screens.MainPage
{
    public class MainPageBridge
    {
        private readonly IMainPage _mainPage;

        public interface IMainPage
        {
            IText Title();
        }

        public MainPageBridge(IMainPage mainPage)
        {
            _mainPage = mainPage;
        }

        public void DisplayTitle(string title)
        {
            IText textBox = _mainPage.Title();
            textBox.Text = title;
        }
    }
}
