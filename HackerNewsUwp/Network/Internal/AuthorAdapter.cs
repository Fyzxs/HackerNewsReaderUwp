using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class AuthorAdapter : INetworkAdapter<Author>
    {
        public Author FromRawContent(string rawContent)
        {
            string rawAuthor = JsonConvert.DeserializeObject<AuthorJson>(rawContent).Author;
            return rawAuthor == null
                ? Author.NullAuthor
                : new Author(rawAuthor);
        }
    }
}