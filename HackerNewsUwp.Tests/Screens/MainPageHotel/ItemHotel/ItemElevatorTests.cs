using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    [TestClass]
    public class ItemElevatorTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayTitleFromNetwork()
        {
            // Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/item/123.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":123, ""title"":""My First TitleInto""}")
                });
            new HackerNewsAccess(fakeResponseHandler);

            // Act
            itemElevator.Load(new ItemId(123L));

            // Assert
            fakeItemView.AssertAgainstTitle(title => title.Should().Be("My First TitleInto"));
        }

    }
}
