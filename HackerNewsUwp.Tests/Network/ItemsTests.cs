﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Network
{
    [TestClass]
    public class ItemsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ConstructorThrowsArgumentExceptionGivenNull()
        {

            ((Action)(() => new Items(null))).ShouldThrow<ArgumentNullException>();
        }

        [TestMethod, TestCategory("unit")]
        public void CountReturnsCountOfItems()
        {
            int count = new Items(new List<ItemId>()).Count();
            count.Should().Be(0);
        }
    }
}
