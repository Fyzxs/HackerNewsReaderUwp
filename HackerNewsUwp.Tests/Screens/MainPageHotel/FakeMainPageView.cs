using System;
using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;
using ItemElevatorTests = HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel.ItemElevatorTests;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    public class FakeMainPageView : MainPageElevator.IMainPageView
    {
        private readonly ItemElevator.IItemView _ivItemView;
        private readonly FakeText _txtTitle = new FakeText();

        internal FakeMainPageView(ItemElevator.IItemView ivItemView = null)
        {
            _ivItemView = ivItemView;
        }

        internal void AssertAgainstTitle(Action<string> assertion) => _txtTitle.AssertAgainstText(assertion);

        public ISetText Title() => _txtTitle;

        public ItemElevator.IItemView ItemView() => _ivItemView;
    }
}