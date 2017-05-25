using System;
using FluentAssertions;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPageHotel.ItemHotel
{
    [TestClass]
    public class ItemElevatorTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayTitle()
        {
            // Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);

            // Act
            itemElevator.Load(new ItemId(123L));

            // Assert
            fakeItemView.AssertAgainstTitle(title => title.Should().Be("This Value"));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldFoo()
        {
            // Arrange
            FakeItemView fakeItemView = new FakeItemView();
            ItemElevator itemElevator = new ItemElevator(fakeItemView);

            // Act
            //Get from network

            // Assert

        }

        public class ItemElevator
        {
            private readonly IItemView _itemView;

            public interface IItemView
            {
                ISetText Title();
            }

            public ItemElevator(IItemView itemView)
            {
                _itemView = itemView;
            }

            public void Load(ItemId itemId)
            {
                _itemView.Title().Text = "This Value";
            }
        }
    }
}
