using HackerNewsUwp.Screens.MainView;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        internal readonly FakeText TxtFakeSetText = new FakeText();
        internal readonly FakeText TxtStoryCount = new FakeText();

        public ISetText Title()
        {
            return TxtFakeSetText;
        }

        public ISetText Count()
        {
            return TxtStoryCount;

        }
    }
}