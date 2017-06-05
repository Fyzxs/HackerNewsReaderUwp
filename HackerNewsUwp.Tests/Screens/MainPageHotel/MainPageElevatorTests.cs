using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel;
using HackerNewsUwp.Tests.Util;
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

            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);

            // Act
            mainPageElevator.DisplayTitle("My Example Text");

            // Assert
            fakeMainPageView.AssertAgainstTitleText(text => text.Should().Be("My Example Text"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayCountOfItems()
        {
            // Arrange
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);

            // Act 
            mainPageElevator.DisplayItems(new Items(new List<ItemId>{null, null, null}));

            // Assert
            fakeMainPageView.TxtStoryCount.AssertAgainstText(text => text.Should().Be("3"));
        }

        [TestMethod, TestCategory("unit'")]
        public void ShouldLoadTitleFromViewLoaded()
        {
            // Arrange
            FakeMainPageView fakeMainPageView = new FakeMainPageView();

            MainPageElevator mainPageElevator = new MainPageElevator(fakeMainPageView);
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/item/14448404.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":14448404, ""title"":""My First TitleInto""}")
                });
            new HackerNewsAccess(fakeResponseHandler);

            // Act 
            mainPageElevator.ViewLoaded();

            // Assert
            fakeMainPageView.AssertAgainstTitleText(txt => txt.Should().Be("My First TitleInto"));
        }
    }
}
