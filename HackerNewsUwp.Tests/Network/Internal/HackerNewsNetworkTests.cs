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
    public class HackerNewsNetworkTests
    {
        private const string HostUrl = "http://blog.quantityandconversion.com";

        [TestMethod]
        public void Exists()
        {
            new HackerNewsNetwork();
        }
        
        [TestMethod]
        public void ShouldReturnTaskStories()
        {
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HostUrl}/topstories.json"), new HttpResponseMessage(HttpStatusCode.OK){Content = new StringContent("You Got It")});
            Task<string> taskStories = new HackerNewsNetwork(fakeResponseHandler).TopStories();
            string actual = taskStories.Result;
            actual.Should().Be("You Got It");
        }
    }
}
