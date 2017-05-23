using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace HackerNewsUwp.Network.Internal
{
    public interface IHackerNewsApi
    {
        [Get("/topstories.json")]
        Task<HttpResponseMessage> TopStories();

        [Get("/item/{itemId}.json")]
        Task<HttpResponseMessage> Item(string itemId);
    }
}