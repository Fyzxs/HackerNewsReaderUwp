using System;
using Windows.ApplicationModel.Email.DataProvider;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    internal class FakeItemView : ItemElevator.IItemView
    {
        private readonly FakeText _txtTitle = new FakeText();
        private readonly FakeText _txtAuthor = new FakeText();

        internal void AssertAgainstTitle(Action<string> assertion) => _txtTitle.AssertAgainstText(assertion);
        internal void AssertAgainstAuthor(Action<string> assertion) => _txtAuthor.AssertAgainstText(assertion);
        public ISetText Title() => _txtTitle;
        public void Loaded()
        {
            throw new NotImplementedException();
        }

        public ISetText Author() => _txtAuthor;
    }
}