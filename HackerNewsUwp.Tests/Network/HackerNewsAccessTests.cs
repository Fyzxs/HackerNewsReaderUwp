using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class HackerNewsAccessTests
    {
        [TestMethod, TestCategory("unit")]
        public async void ShouldReturnTaskItems()
        {
            // Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234}]")
                });
            IResponse<Items> response = await new HackerNewsAccess(fakeResponseHandler).TopStories();

            // Act
            int count = response.Body().Count();

            // Assert
            count.Should().Be(2);
        }

        [TestMethod, TestCategory("unit")]
        public async void ShouldReturnSpecifiedItem()
        {
            // Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            ItemId itemId = new ItemId(123L);
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/item/123.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":123, ""title"":""My First TitleInto""}")
                });
            IResponse<Item> response = await new HackerNewsAccess(fakeResponseHandler).Item(itemId);

            Item item = response.Body();
            FakeText fakeSetText = new FakeText();

            // Act
            item.TitleInto(fakeSetText);

            // Assert
            fakeSetText.AssertAgainstText(text => text.Should().Be("My First TitleInto"));
        }
    }
}