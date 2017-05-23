using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Screens.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class TitleAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void AdapterReturnsValidItemId()
        {
            // Arrange 
            const string rawContent = @"{""id"":123, ""title"":""My First TitleInto""}";
            TitleAdapter adapter = new TitleAdapter();
            FakeText titleInto = new FakeText();

            // Act
            Title title = adapter.FromRawContent(rawContent);

            // Assert
            title.TitleInto(titleInto);
            titleInto.Text.Should().Be("My First TitleInto");
        }
    }
}