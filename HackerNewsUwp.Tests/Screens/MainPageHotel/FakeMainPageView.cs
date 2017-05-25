using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        internal readonly FakeText TxtTitle = new FakeText();
        internal readonly FakeText TxtStoryCount = new FakeText();

        public ISetText Title()
        {
            return TxtTitle;
        }

        public ISetText Count()
        {
            return TxtStoryCount;

        }
    }
}