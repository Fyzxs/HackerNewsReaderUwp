using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;

namespace HackerNewsUwp.Tests.Network
{

    [TestClass]
    public class ResponseTests
    {
        [TestMethod]
        public void CtorShouldThrowNullReferenceExceptionGivenNull()
        {
            Action action = () => new Response<ItemId>(null, null, null);
            action.ShouldThrow<NullReferenceException>();
        }

        [TestMethod]
        public void StatusCodeShouldProvideHttpResponseMessageStatusCode()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.OK), null, null).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null, null).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }
        [TestMethod]
        public async Task StatusCodeShouldProvideApiExceptionStatusCode()
        {
            new Response<ItemId>(null, null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK))).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response<ItemId>(null, null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public void MessageShouldReturnHttpResponseMessageContent()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") }, null, null).Message().Should().Be("Values Go Here");
        }

        [TestMethod]
        public async Task MessageShouldReturnApiExceptionContent()
        {
            new Response<ItemId>(null, null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") })).Message().Should().Be("Values Go Here");
        }

        [TestMethod]
        public void MessageShouldReturnNullGivenNoHttpResponseMessageContent()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null, null).Message().Should().BeNull();
        }

        [TestMethod]
        public async Task MessageShouldReturnNullGivenNoApiExceptionContent()
        {
            new Response<ItemId>(null, null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).Message().Should().BeNull();
        }

        [TestMethod]
        public void BodyShouldReturnObjectGivenHttpResponseMessageSuccess()
        {
            int memberInfoId = new Random().Next();
            TestItemId itemId = new Response<TestItemId>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") }, null, null).Body();

            itemId.Id.Should().Be(memberInfoId);
        }

        [TestMethod]
        public async Task BodyShouldReturnObjectGivenApiExceptionSuccess()
        {
            int memberInfoId = new Random().Next();
            TestItemId itemId = new Response<TestItemId>(null, null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") })).Body();

            itemId.Id.Should().Be(memberInfoId);
        }

        [TestMethod]
        public void BodyShouldSomethingGivenFailure()
        {
            ItemId itemId = new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null, null).Body();

            itemId.Should().BeNull();
        }

        [TestMethod]
        public void BodyShouldUseCustomAdapterWhenAvailable()
        {
            string customized = new Response<string>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":2}}") }, new CustomizedAdapter(), null).Body();

            customized.Should().Be("Not the Same Value");
        }

        public class CustomizedAdapter : INetworkAdapter<string>
        {
            public string FromRawContent(string rawContent)
            {
                return "Not the Same Value";
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class TestItemId
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public long Id { get; set; }
        }

    }
}
