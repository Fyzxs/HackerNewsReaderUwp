using System.Collections.Generic;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    [TestClass]
    public class MainPageElevatorTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldSetTextOnTitle()
        {
            // Arrange
            FakeItemView fakeItemView = new FakeItemView();
            FakeMainPageView fakeMainPageView = new FakeMainPageView(fakeItemView);
            Item item = new Item(ItemId.NullItemId, new Title("My Example Text"), Author.NullAuthor);
            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);

            // Act
            mainPageElevator.DisplayItem(item);

            // Assert
            fakeItemView.AssertAgainstTitle(text => text.Should().Be("My Example Text"));
        }

    }
}
