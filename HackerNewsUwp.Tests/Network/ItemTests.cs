using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Screens.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network {

    [TestClass]
    public class ItemTests
    {

        [TestMethod, TestCategory("unit")]
        public void TitleShouldBeCorrect()
        {
            // Arrange
            Item item = new Item(new ItemId(123L), new Title("This is my Title"));
            FakeText fakeText = new FakeText();

            // Act
            item.TitleInto(fakeText);

            // Assert
            fakeText.Text.Should().Be("This is my Title");
        }
    }
}