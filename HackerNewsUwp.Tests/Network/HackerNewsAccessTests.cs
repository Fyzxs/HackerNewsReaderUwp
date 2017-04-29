using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class HackerNewsAccessTests
    {
        private const string HostUrl = "http://blog.quantityandconversion.com";

        [TestMethod]
        public async Task ShouldReturnTaskItems()
        {
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/topstories.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"[{""id"":123},{""id"":1234}]")
                });
            Response<Items> response = await new HackerNewsAccess(fakeResponseHandler).TopStories();
            int count = response.Body().Count();
            count.Should().Be(2);
        }
    }
}