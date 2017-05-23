using System;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Tests.Screens.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network {

    [TestClass]
    public class ItemTests
    {

        [TestMethod]
        public void TitleShouldSetConstructorText()
        {
            // Arrange
            Item item = new Item();
            FakeText fakeText = new FakeText();

            // Act
            item.TitleInto(fakeText);

            // Assert
            fakeText.Text.Should().Be("My First TitleInto");
        }
    }
}