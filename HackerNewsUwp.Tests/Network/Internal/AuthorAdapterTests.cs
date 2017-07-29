using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class AuthorAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void AdapterReturnsValidAuthor()
        {
            // Arrange 
            const string rawContent = @"{""id"":123, ""title"":""My First TitleInto"", ""by"":""The Author Guy""}";
            AuthorAdapter adapter = new AuthorAdapter();
            FakeText into = new FakeText();

            // Act
            Author author = adapter.FromRawContent(rawContent);

            // Assert
            author.Into(into);
            into.AssertAgainstText(text => text.Should().Be("The Author Guy"));
        }
        [TestMethod, TestCategory("unit")]
        public void AdapterReturnsNullObjectForMissingAuthor()
        {
            // Arrange 
            const string rawContent = @"{""id"":123}";
            AuthorAdapter adapter = new AuthorAdapter();

            // Act
            Author title = adapter.FromRawContent(rawContent);

            // Assert
            title.Should().BeSameAs(Author.NullAuthor);
        }
    }
}