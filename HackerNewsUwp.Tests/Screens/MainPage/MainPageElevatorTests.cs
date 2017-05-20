using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens;
using HackerNewsUwp.Screens.MainView;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageBridgeTests
    {

        [TestMethod]
        public void ShouldSetTextOnTitle()
        {
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageBridge mainPageBridge = new MainPageBridge(fakeMainPageView);

            mainPageBridge.DisplayTitle("My Example Text");

            fakeMainPageView.TxtFakeText.Text.Should().Be("My Example Text");
        }

        [TestMethod]
        public void ShouldDisplayCountOfItems()
        {
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageBridge mainPageBridge = new MainPageBridge(fakeMainPageView);

            mainPageBridge.DisplayItems(new Items(new ItemId[]{null, null, null}));

            fakeMainPageView.TxtStoryCount.Text.Should().Be("3");
        }
    }
}
