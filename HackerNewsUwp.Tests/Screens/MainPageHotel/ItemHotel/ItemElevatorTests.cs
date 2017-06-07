using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens.MainPageHotel.ItemHotel;
using HackerNewsUwp.Tests.Network.Internal;
using HackerNewsUwp.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    [TestClass]
    public class ItemElevatorTests
    {
        [TestMethod, TestCategory("integration")]
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

        [TestMethod, TestCategory("integration")]
        public void ShouldDisplayAuthorFromNetwork()
        {
            // Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);
            FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri($"{HackerNewsAccess.HostUrl}/item/123.json"),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"{""id"":123, ""title"":""My First TitleInto"", ""author"":""Some Guy""}")
                });
            new HackerNewsAccess(fakeResponseHandler);
             
            // Act
            itemElevator.Load(new ItemId(123L));

            // Assert
            fakeItemView.AssertAgainstAuthor(txt => txt.Should().Be("Some Guy"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShoudlDisplayTitleFromFake()
        {
            //Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);
            Item item = new Item(ItemId.NullItemId, new Title("Sample Tittle"), Author.NullAuthor);

            //Act
            itemElevator.Update(item);

            //Assert
            fakeItemView.AssertAgainstTitle(txt => txt.Should().Be("Sample Tittle"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShoudlDisplayAuthorFromFake()
        {
            //Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);
            Item item = new Item(ItemId.NullItemId, Title.NullTitle, new Author("Some Guy"));

            //Act
            itemElevator.Update(item);

            //Assert
            fakeItemView.AssertAgainstAuthor(txt => txt.Should().Be("Some Guy"));
        }
    }
}
