using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class ItemsAdapterTests
    {
        [TestMethod]
        public void ShouldCreateItemsCallingToObject()
        {
            // Arrange
            // Act
            Items items = new ItemsAdapter().FromRawContent("[]");

            // Assert
            items.Should().NotBeNull();
        }
    }
}
