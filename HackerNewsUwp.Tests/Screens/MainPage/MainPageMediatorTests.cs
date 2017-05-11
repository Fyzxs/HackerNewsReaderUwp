using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainView;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageMediatorTests
    {
        [TestMethod]
        public void ShouldGetItems()
        {
            FakeMainPageView fakeMainPageView = new FakeMainPageView();
            MainPageBridge mainPageBridge = new MainPageBridge(fakeMainPageView);
            MainPageMediator mainPageMediator = new MainPageMediator(mainPageBridge);

            mainPageMediator.DisplayItems(new Items(new ItemId[]{ null, null, null, null }));

            fakeMainPageView.TxtStoryCount.Text.Should().Be("4");
        }
    }
    

    public class MainPageMediator
    {
        private readonly MainPageBridge _mainPageBridge;

        public MainPageMediator(MainPageBridge mainPageBridge)
        {
            _mainPageBridge = mainPageBridge;
        }

        public void DisplayItems(Items items)
        {
            _mainPageBridge.DisplayItems(items);
        }
    }
}