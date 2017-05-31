using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;
using ItemElevatorTests = HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel.ItemElevatorTests;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        private readonly ItemElevatorTests.ItemElevator.IItemView _ivItemView;
        internal readonly FakeText TxtTitle = new FakeText();
        internal readonly FakeText TxtStoryCount = new FakeText();

        internal FakeMainPageView(ItemElevatorTests.ItemElevator.IItemView ivItemView = null)
        {
            _ivItemView = ivItemView;
        }

        public ISetText Title() => TxtTitle;

        public ISetText Count() => TxtStoryCount;
    }
}