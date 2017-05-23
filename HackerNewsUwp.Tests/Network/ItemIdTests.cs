using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class ItemIdTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnIdAsString()
        {
            // Arrange
            ItemId itemId = new ItemId(123L);

            // Act
            string itemIdAsString = itemId.IdAsString();

            // Assert

            itemIdAsString.Should().Be("123");
        }
    }
}