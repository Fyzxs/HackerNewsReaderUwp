using System.Collections.Generic;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainView;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageElevatorTests
    {

        [TestMethod]
        public void ShouldSetTextOnTitle()
        {
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageBridge = new MainPageElevator(fakeMainPageView);

            mainPageBridge.DisplayTitle("My Example Text");

            fakeMainPageView.TxtFakeSetText.Text.Should().Be("My Example Text");
        }

        [TestMethod]
        public void ShouldDisplayCountOfItems()
        {
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageBridge = new MainPageElevator(fakeMainPageView);

            mainPageBridge.DisplayItems(new Items(new List<ItemId>{null, null, null}));

            fakeMainPageView.TxtStoryCount.Text.Should().Be("3");
        }
    }
}
