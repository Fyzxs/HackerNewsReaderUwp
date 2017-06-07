using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Network.Internal
{
    public class Title
    {
        private class NullObject : Title
        {
            public NullObject() : base("[Null Title]")
            {
            }

            public override void Into(ISetText item)
            {
                // No Op
            }
        }
        public static Title NullTitle = new NullObject();

        private readonly string _title;
        public Title(string title)
        {
            _title = title;
        }

        public virtual void Into(ISetText item)
        {
            item.Text = _title;
        }
    }
}
