using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Network.Internal
{
    public class Author
    {
        private class NullObject : Author
        {
            public NullObject() : base("[Null Author]")
            {
            }

            public override void Into(ISetText item)
            {
                // No Op
            }
        }
        public static Author NullAuthor = new NullObject();
        private readonly string _author;

        public Author(string author) => _author = author;

        public virtual void Into(ISetText item) => item.Text = _author;
    }
}