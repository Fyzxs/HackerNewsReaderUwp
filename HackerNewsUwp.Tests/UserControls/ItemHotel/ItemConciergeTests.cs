using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls.ItemHotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HackerNewsUwp.Tests.UserControls.ItemHotel
{
    [TestClass]
    public class ItemConciergeTests
    {
        [TestMethod]
        public async void ShouldLoadItem()
        {
            //Arrange
            ItemConcierge itemConcierge = new ItemConcierge();
            FakeHackerNewsAccess fakeHackerNewsAccess = new FakeHackerNewsAccess();
            ItemId itemId = new ItemId(1234L);
            Item expected = new Item(itemId, new Title("Some Title"), new Author("Some Author"));
            FakeResponse<Item> fakeResponse = new FakeResponse<Item>(expected);
            Task<IResponse<Item>> task = new TaskFactory<IResponse<Item>>().StartNew(() => fakeResponse);
            fakeHackerNewsAccess.ItemReturn(task);

            //Act
            Item actual = await itemConcierge.Load(itemId, fakeHackerNewsAccess);

            //Assert
            actual.Should().Be(expected);
        }

    }

    public class FakeResponse<T> : IResponse<T> where T : class
    {
        private readonly T _body;

        public FakeResponse(T body)
        {
            _body = body;
        }

        public HttpStatusCode StatusCode()
        {
            throw new System.NotImplementedException();
        }

        public string Message()
        {
            throw new System.NotImplementedException();
        }

        public T Body() => _body;
    }

    internal class FakeHackerNewsAccess : IHackerNewsAccess
    {
        private Task<IResponse<Item>> _response;

        public Task<IResponse<Items>> TopStories()
        {
            throw new System.NotImplementedException();
        }


        public Task<IResponse<Item>> Item(ItemId itemId)
        {
            Task.Delay(1);
            return _response;
        }

        public void ItemReturn(Task<IResponse<Item>> response)
        {
            _response = response;
        }
    }
}
