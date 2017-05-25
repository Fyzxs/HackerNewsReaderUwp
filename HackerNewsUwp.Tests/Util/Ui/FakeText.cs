using System;
using FluentAssertions;
using FluentAssertions.Primitives;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Tests.Util.Ui
{
    internal class FakeText : ISetText
    {
        public string Text { private get; set; }

        internal void AssertAgainstText(Action<string> assertion) => assertion(Text);
    }
}