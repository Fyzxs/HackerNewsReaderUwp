using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class ItemsTests
    {
        [TestMethod]
        public void ConstructorThrowsArgumentExceptionGivenNull()
        {

            Action action = () => new Items(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void CountReturnsCountOfItems()
        {
            int count = new Items(new ItemId[0]).Count();
            count.Should().Be(0);
        }
    }
}
