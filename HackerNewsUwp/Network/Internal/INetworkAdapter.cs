using System.Net.Http;

namespace HackerNewsUwp.Network.Internal
{
    public interface INetworkAdapter<out T>
    {
        T FromRawContent(string rawContent);
    }
}