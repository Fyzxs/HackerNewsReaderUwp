using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class ItemIdAdapterTests
    {
        [TestMethod, TestCategory("unit")]
        public void AdapterReturnsValidItemId()
        {
            // Arrange 
            const string rawContent = @"{""id"":123, ""title"":""My First TitleInto""}";
            ItemIdAdapter adapter = new ItemIdAdapter();

            // Act
            ItemId itemId = adapter.FromRawContent(rawContent);

            // Assert

            itemId.IdAsString().Should().Be("123");
        }
    }
}