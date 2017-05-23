namespace HackerNewsUwp.Network.Internal
{
    public partial class ItemId
    {
        private readonly long _id;
        
        public ItemId(long id) => _id = id;
    }

    public partial class ItemId
    {
        public string IdAsString() => _id.ToString();
    }
}
