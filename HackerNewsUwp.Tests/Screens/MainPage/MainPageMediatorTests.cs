using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainView;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageMediatorTests
    {
        private const string HostUrl = "http://quinngil.com";
        
        [TestMethod]
        public async Task ShouldLoadItemsFromNetwork()
        {
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234},{""id"":12345}]")
                });

            HackerNewsAccess hackerNewsAccess = new HackerNewsAccess(fakeResponseHandler);
            FakeMainPageView fakeMainPageView = new FakeMainPageView();
            MainPageBridge mainPageBridge = new MainPageBridge(fakeMainPageView);
            MainPageMediator mainPageMediator = new MainPageMediator(mainPageBridge, hackerNewsAccess);
            await mainPageMediator.LoadItems();
            fakeMainPageView.TxtStoryCount.Text.Should().Be("3");
        }
    }
    

    public class MainPageMediator
    {
        private readonly HackerNewsAccess _hackerNewsAccess;
        private readonly MainPageBridge _mainPageBridge;
        
        public MainPageMediator(MainPageBridge mainPageBridge, HackerNewsAccess hackerNewsAccess)
        {
            _mainPageBridge = mainPageBridge;
            _hackerNewsAccess = hackerNewsAccess;
        }

        private void DisplayItems(Items items) => _mainPageBridge.DisplayItems(items);
        public async Task LoadItems() => DisplayItems((await _hackerNewsAccess.TopStories()).Body());
    }
}