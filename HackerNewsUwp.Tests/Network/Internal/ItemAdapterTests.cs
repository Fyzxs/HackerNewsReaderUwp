using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Screens.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class ItemAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnItem()
        {
            // Arrange
            const string rawContent = @"{""id"":123, ""title"":""Some Text here""}";
            ItemAdapter itemAdapter = new ItemAdapter();
            Item item = itemAdapter.FromRawContent(rawContent);
            FakeText title = new FakeText();

            // Act 
            item.TitleInto(title);

            // Assert
            title.Text.Should().Be("Some Text here");
        }
    }
}
