using System.Collections.Generic;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel;
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
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageBridge = new MainPageElevator(fakeMainPageView);

            // Act
            mainPageBridge.DisplayTitle("My Example Text");

            // Assert
            fakeMainPageView.TxtTitle.AssertAgainstText(text => text.Should().Be("My Example Text"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayCountOfItems()
        {
            // Arrange
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageBridge = new MainPageElevator(fakeMainPageView);

            // Act 
            mainPageBridge.DisplayItems(new Items(new List<ItemId>{null, null, null}));

            // Assert
            fakeMainPageView.TxtStoryCount.AssertAgainstText(text => text.Should().Be("3"));
        }
    }
}
