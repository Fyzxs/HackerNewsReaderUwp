using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using FluentAssertions;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.Screens;
using HackerNewsUwp.Screens.MainPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsUwp.Tests.Screens.MainPage
{
    [TestClass]
    public class MainPageBridgeTests
    {

        [TestMethod]
        public void ShouldSetTextOnTitle()
        {
            FakeMainPage fakeMainPage = new FakeMainPage();

            MainPageBridge mainPageBridge = new MainPageBridge(fakeMainPage);

            mainPageBridge.DisplayTitle("My Example Text");

            fakeMainPage.TxtFakeText.Text.Should().Be("My Example Text");
        }

    }
    
    public class FakeText : IText
    {
        public string Text { get; set; }
    }

    public class FakeMainPage : MainPageBridge.IMainPage
    {
        internal FakeText TxtFakeText = new FakeText();
        public IText Title()
        {
            return TxtFakeText;
        }
    }
}
