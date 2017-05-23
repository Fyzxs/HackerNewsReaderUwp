namespace HackerNewsUwp.Network.Internal
{
    public partial class ItemId
    {
        private readonly long _id;
        
        public ItemId(long id) => _id = id;
    }

    public partial class ItemId
    {
        internal string IdAsString() => _id.ToString();
    }
}
