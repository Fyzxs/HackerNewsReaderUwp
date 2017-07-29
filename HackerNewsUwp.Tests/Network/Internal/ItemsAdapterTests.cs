using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class ItemsAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCreateItemsCallingToObject()
        {
            // Arrange
            const string rawContent = "[]";

            // Act
            Items items = new ItemsAdapter().FromRawContent(rawContent);

            // Assert
            items.Should().NotBeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldCreateItem()
        {
            // Arrange
            const string rawContent = @"[123]";

            // Act
            Items items = new ItemsAdapter().FromRawContent(rawContent);

            // Assert
            items.Count().Should().Be(1);
        }
    }
}
