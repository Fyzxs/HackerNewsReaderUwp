using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using HackerNewsUwp.UserControls;
using HackerNewsUwp.UserControls.ItemHotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HackerNewsUwp.Tests.UserControls.ItemHotel
{
    [TestClass]
    public class ItemElevatorTests
    {
        [TestMethod]
        public void ShouldPopulateTitle()
        {
            //Arrange
            FakeItemRoom fakeRoom = new FakeItemRoom();
            FakeItemConcierge fakeConcierge = new FakeItemConcierge();
            FakeHackerNewsAccess fakeHackerNewsAccess = new FakeHackerNewsAccess();
            Task<Item> task = new TaskFactory<Item>().StartNew(() => new Item(ItemId.NullItemId, new Title("Some Title"), Author.NullAuthor));
            fakeConcierge.LoadReturn(task);

            ItemElevator itemElevator = new ItemElevator(new ItemId(1234L), fakeConcierge, fakeHackerNewsAccess);

            //Act
            itemElevator.Load(fakeRoom);

            //Assert
            fakeRoom.VerifyTitle((txt) => txt.Should().Be("Some Title"));
        }
        [TestMethod]
        public void ShouldPopulateAuthor()
        {
            //Arrange
            FakeItemRoom fakeRoom = new FakeItemRoom();
            FakeItemConcierge fakeConcierge = new FakeItemConcierge();
            FakeHackerNewsAccess fakeHackerNewsAccess = new FakeHackerNewsAccess();
            ItemElevator itemElevator = new ItemElevator(new ItemId(1234L), fakeConcierge, fakeHackerNewsAccess);

            Task<Item> task = new TaskFactory<Item>().StartNew(() => new Item(ItemId.NullItemId, Title.NullTitle, new Author("Some Guy")));
            fakeConcierge.LoadReturn(task);

            //Act
            itemElevator.Load(fakeRoom);

            //Assert
            fakeRoom.VerifyAuthor((txt) => txt.Should().Be("Some Guy"));
        }

    }

    internal class FakeItemConcierge : ItemConcierge.IConcierge
    {
        private Task<Item> _loadReturn;

        public Task<Item> Load(ItemId itemId, IHackerNewsAccess hackerNewwsAccess) => _loadReturn;

        internal void LoadReturn(Task<Item> loadReturn) => _loadReturn = loadReturn;
    }

    internal class FakeItemRoom : ItemElevator.IRoom
    {
        private readonly FakeText _title = new FakeText();
        private readonly FakeText _author = new FakeText();

        public ISetText Title() => _title;
        public ISetText Author() => _author;

        public void VerifyTitle(Action<string> assertion) => _title.AssertAgainstText(assertion);
        public void VerifyAuthor(Action<string> assertion) => _author.AssertAgainstText(assertion);
    }
}
