using System;
using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        private readonly ItemElevator.IItemView _ivItemView;
        private readonly FakeText _txtTitle = new FakeText();
        internal readonly FakeText TxtStoryCount = new FakeText();

        internal FakeMainPageView(ItemElevator.IItemView ivItemView = null) => _ivItemView = ivItemView;

        internal void AssertAgainstTitleText(Action<string> assertion) => _txtTitle.AssertAgainstText(assertion);

        public ISetText Title() => _txtTitle;

        public ISetText Count() => TxtStoryCount;
        
    }
}