using System.Threading.Tasks;
using Refit;

namespace HackerNewsUwp.Network
{
    public interface IHackerNewsApi
    {
        [Get("/topstories.json")]
        Task<string> TopStories();
    }
}