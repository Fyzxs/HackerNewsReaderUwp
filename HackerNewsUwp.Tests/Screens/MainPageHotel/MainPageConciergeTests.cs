using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel
{
    [TestClass]
    public class MainPageConciergeTests
    {
        
        [TestMethod, TestCategory("unit")]
        public void ShouldLoadItemsFromNetwork()
        {
            //Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234},{""id"":12345}]")
                });

            HackerNewsAccess hackerNewsAccess = new HackerNewsAccess(fakeResponseHandler);
            FakeMainPageView fakeMainPageView = new FakeMainPageView();
            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);
            MainPageConcierge mainPageConcierge = new MainPageConcierge(mainPageElevator, hackerNewsAccess);
            
            //Act
            mainPageConcierge.LoadItems();
            
            //Assert
            fakeMainPageView.TxtStoryCount.AssertAgainstText(text => text.Should().Be("3"));
        }


        [TestMethod, TestCategory("unit")]
        public async void ShouldLoadItemFromNetwork()
        {
            // Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234},{""id"":12345}]")
                });

            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/item/1234.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":1234, ""title"":""This is my title""}")
                });

            HackerNewsAccess hackerNewsAccess = new HackerNewsAccess(fakeResponseHandler);

            FakeMainPageView fakeMainPageView = new FakeMainPageView();
            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);
            MainPageConcierge mainPageConcierge = new MainPageConcierge(mainPageElevator, hackerNewsAccess);

            mainPageConcierge.LoadItems();

            //Act
            await mainPageConcierge.LoadItem(new ItemId(1234L));

            //Assert
            fakeMainPageView.AssertAgainstTitleText(text => text.Should().Be("This is my title"));
        }
    }
}