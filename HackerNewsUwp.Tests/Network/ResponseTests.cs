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
        [TestMethod, TestCategory("unit")]
        public void CtorShouldThrowNullReferenceExceptionGivenNull()
        {
            Action action = () => new Response<ItemId>(null, null);
            action.ShouldThrow<NullReferenceException>();
        }

        [TestMethod, TestCategory("unit")]
        public void StatusCodeShouldProvideHttpResponseMessageStatusCode()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.OK), null).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }
        [TestMethod, TestCategory("unit")]
        public async void StatusCodeShouldProvideApiExceptionStatusCode()
        {
            new Response<ItemId>(await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK))).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response<ItemId>(await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }

        [TestMethod, TestCategory("unit")]
        public void MessageShouldReturnHttpResponseMessageContent()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") }, null).Message().Should().Be("Values Go Here");
        }

        [TestMethod, TestCategory("unit")]
        public async void MessageShouldReturnApiExceptionContent()
        {
            new Response<ItemId>(await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") })).Message().Should().Be("Values Go Here");
        }

        [TestMethod, TestCategory("unit")]
        public void MessageShouldReturnNullGivenNoHttpResponseMessageContent()
        {
            new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).Message().Should().BeNull();
        }

        [TestMethod, TestCategory("unit")]
        public async void MessageShouldReturnNullGivenNoApiExceptionContent()
        {
            new Response<ItemId>(await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).Message().Should().BeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void BodyShouldReturnObjectGivenHttpResponseMessageSuccess()
        {
            int memberInfoId = new Random().Next();
            TestItemId itemId = new Response<TestItemId>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") }, null).Body();

            itemId.Id.Should().Be(memberInfoId);
        }

        [TestMethod, TestCategory("unit")]
        public async void BodyShouldReturnObjectGivenApiExceptionSuccess()
        {
            int memberInfoId = new Random().Next();
            TestItemId itemId = new Response<TestItemId>(await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") })).Body();

            itemId.Id.Should().Be(memberInfoId);
        }

        [TestMethod, TestCategory("unit")]
        public void BodyShouldSomethingGivenFailure()
        {
            ItemId itemId = new Response<ItemId>(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).Body();

            itemId.Should().BeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void BodyShouldUseCustomAdapterWhenAvailable()
        {
            string customized = new Response<string>(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":2}}") }, new CustomizedAdapter()).Body();

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
