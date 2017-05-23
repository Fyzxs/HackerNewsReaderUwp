using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Screens.MainView;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageConciergeTests
    {
        private const string HostUrl = "http://quinngil.com";
        
        [TestMethod, TestCategory("unit")]
        public async Task ShouldLoadItemsFromNetwork()
        {
            //Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234},{""id"":12345}]")
                });

            HackerNewsAccess hackerNewsAccess = new HackerNewsAccess(fakeResponseHandler);
            FakeMainPageView fakeMainPageView = new FakeMainPageView();
            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);
            MainPageConcierge mainPageConcierge = new MainPageConcierge(mainPageElevator, hackerNewsAccess);
            
            //Act
            await mainPageConcierge.LoadItems();
            
            //Assert
            fakeMainPageView.TxtStoryCount.Text.Should().Be("3");
        }
        
    }
}