using System;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    internal class FakeItemView : ItemElevatorTests.ItemElevator.IItemView
    {
        private readonly FakeText _txtTitle = new FakeText();

        internal void AssertAgainstTitle(Action<string> assertion) => _txtTitle.AssertAgainstText(assertion);
        public ISetText Title() => _txtTitle;
    }
}