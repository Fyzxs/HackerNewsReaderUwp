using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            Action action = () => new Response(null, null);
            action.ShouldThrow<NullReferenceException>();
        }

        [TestMethod]
        public void StatusCodeShouldProvideHttpResponseMessageStatusCode()
        {
            new Response(new HttpResponseMessage(HttpStatusCode.OK), null).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }
        [TestMethod]
        public async Task StatusCodeShouldProvideApiExceptionStatusCode()
        {
            new Response(null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK))).StatusCode().Should().Be(HttpStatusCode.OK);
            new Response(null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).StatusCode().Should().Be(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public void MessageShouldReturnHttpResponseMessageContent()
        {
            new Response(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") }, null).Message().Should().Be("Values Go Here");
        }

        [TestMethod]
        public async Task MessageShouldReturnApiExceptionContent()
        {
            new Response(null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Values Go Here") })).Message().Should().Be("Values Go Here");
        }

        [TestMethod]
        public void MessageShouldReturnNullGivenNoHttpResponseMessageContent()
        {
            new Response(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).Message().Should().BeNull();
        }

        [TestMethod]
        public async Task MessageShouldReturnNullGivenNoApiExceptionContent()
        {
            new Response(null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.Unauthorized))).Message().Should().BeNull();
        }

        [TestMethod]
        public void BodyShouldReturnObjectGivenHttpResponseMessageSuccess()
        {
            int memberInfoId = new Random().Next();
            ItemJson itemJson = new Response(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") }, null).Body();

            itemJson.Id.Should().Be(memberInfoId);
        }

        [TestMethod]
        public async Task BodyShouldReturnObjectGivenApiExceptionSuccess()
        {
            int memberInfoId = new Random().Next();
            ItemJson itemJson = new Response(null, await ApiException.Create(null, null, new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{{\"id\":{memberInfoId}}}") })).Body();

            itemJson.Id.Should().Be(memberInfoId);
        }

        [TestMethod]
        public void BodyShouldSomethingGivenFailure()
        {
            ItemJson itemJson = new Response(new HttpResponseMessage(HttpStatusCode.Unauthorized), null).Body();

            itemJson.Should().BeNull();
        }

    }
}
