using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldWriteIntoSetText()
        {
            // Arrange
            Author author = new Author("This Value");
            FakeText fakeText = new FakeText();

            // Act
            author.Into(fakeText);

            // Assert
            fakeText.AssertAgainstText(txt => txt.Should().Be("This Value"));
        }      
    }
}
