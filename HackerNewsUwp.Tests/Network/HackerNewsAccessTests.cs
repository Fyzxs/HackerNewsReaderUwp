using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Screens.MainPage;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class HackerNewsAccessTests
    {
        private const string HostUrl = "http://quinngil.com";

        [TestMethod, TestCategory("unit")]
        public async Task ShouldReturnTaskItems()
        {
            // Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234}]")
                });
            Response<Items> response = await new HackerNewsAccess(fakeResponseHandler).TopStories();

            // Act
            int count = response.Body().Count();

            // Assert
            count.Should().Be(2);
        }

        [TestMethod, TestCategory("unit")]
        public async Task ShouldReturnSpecifiedItem()
        {
            // Arrange
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            ItemId itemId = new ItemId(123L);
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/item/123.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":123, ""title"":""My First TitleInto""}")
                });
            Response<Item> response = await new HackerNewsAccess(fakeResponseHandler).Item(itemId);

            Item item = response.Body();
            FakeText fakeSetText = new FakeText();

            // Act
            item.TitleInto(fakeSetText);

            // Assert
            fakeSetText.Text.Should().Be("My First TitleInto");
        }
    }
}