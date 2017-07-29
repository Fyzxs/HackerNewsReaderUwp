using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class ItemAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnItemWithTitle()
        {
            // Arrange
            const string rawContent = @"{""id"":123, ""title"":""Some Text here"", ""by"":""The Author Guy""}";
            ItemAdapter itemAdapter = new ItemAdapter();
            Item item = itemAdapter.FromRawContent(rawContent);
            FakeText title = new FakeText();

            // Act 
            item.TitleInto(title);

            // Assert
            title.AssertAgainstText(text => text.Should().Be("Some Text here"));
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnItemWithAuthor()
        {
            // Arrange
            const string rawContent = @"{""id"":123, ""title"":""Some Text here"", ""by"":""The Author Guy""}";
            ItemAdapter itemAdapter = new ItemAdapter();
            Item item = itemAdapter.FromRawContent(rawContent);
            FakeText fakeText = new FakeText();

            // Act 
            item.AuthorInto(fakeText);

            // Assert
            fakeText.AssertAgainstText(text => text.Should().Be("The Author Guy"));
        }
    }
}
