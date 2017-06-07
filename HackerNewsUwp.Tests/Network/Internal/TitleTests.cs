using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Tests.Util.Ui;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network.Internal
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldSetTitleInto()
        {
            // Arrange
            Title title = new Title("Text goes here");
            FakeText titleInto = new FakeText();

            // Act
            title.Into(titleInto);

            // Assert
            titleInto.AssertAgainstText(text => text.Should().Be("Text goes here"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldNotSetTitleIntoFromNullObject()
        {
            FakeText titleInto = new FakeText();
            Title nullTitle = Title.NullTitle;
            nullTitle.Into(titleInto);

            titleInto.AssertAgainstText(text => text.Should().BeNull());
        }
    }
}