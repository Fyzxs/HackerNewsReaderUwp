using HackerNewsUwp.Screens.MainView;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        internal readonly FakeText TxtFakeText = new FakeText();
        internal readonly FakeText TxtStoryCount = new FakeText();

        public IText Title()
        {
            return TxtFakeText;
        }

        public IText Count()
        {
            return TxtStoryCount;

        }
    }
}