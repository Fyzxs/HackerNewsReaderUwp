using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network {

    [TestClass]
    public class ItemTests
    {

        [TestMethod, TestCategory("unit")]
        public void TitleShouldBeCorrect()
        {
            // Arrange
            Item item = new Item(ItemId.NullItemId, new Title("This is my Title"), Author.NullAuthor);
            FakeText fakeText = new FakeText();

            // Act
            item.TitleInto(fakeText);

            // Assert
            fakeText.AssertAgainstText(text => text.Should().Be("This is my Title"));
        }
    }
}