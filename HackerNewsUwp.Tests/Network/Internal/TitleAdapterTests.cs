using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class TitleAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void AdapterReturnsValid()
        {
            // Arrange 
            const string rawContent = @"{""id"":123, ""title"":""My First TitleInto""}";
            TitleAdapter adapter = new TitleAdapter();
            FakeText titleInto = new FakeText();

            // Act
            Title title = adapter.FromRawContent(rawContent);

            // Assert
            title.Into(titleInto);
            titleInto.AssertAgainstText(text => text.Should().Be("My First TitleInto"));
        }
    }
}