using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class AuthorAdapter : INetworkAdapter<Author>
    {
        public Author FromRawContent(string rawContent)
        {
            return new Author(JsonConvert.DeserializeObject<AuthorJson>(rawContent).Author);
        }
    }
}