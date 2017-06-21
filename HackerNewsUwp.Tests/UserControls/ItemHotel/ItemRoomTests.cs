using HackerNewsUwp.UserControls.ItemHotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.UserControls.ItemHotel
{
    [TestClass]
    public class ItemRoomTests
    {
        /*
            ItemRoom is an interface applied to a UI Widget.
            
            There's no tests around ItemRoom itself.
            
            Whatever UI Widget implements ItemElevator.IRoom is going to be simple to the point of testing the framework.

            So there's no tests. But I felt the need to explain why.

            And when I find I'm wrong; I'll fix it.
         */
        public class FakeItemElevator : ItemConcierge.IElevator
        {
        }
    }
}
