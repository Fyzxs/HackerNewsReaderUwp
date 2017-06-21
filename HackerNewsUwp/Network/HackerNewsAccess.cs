using HackerNewsUwp.Network.Internal;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsUwp.Network
{
    public interface IHackerNewsAccess
    {
        Task<IResponse<Items>> TopStories();
        Task<IResponse<Item>> Item(ItemId itemId);
    }

    public class HackerNewsAccess : IHackerNewsAccess
    {
        public const string HostUrl = "https://hacker-news.firebaseio.com/v0/";
        private static HttpMessageHandler _messageHandler;

        public HackerNewsAccess() { }

        public HackerNewsAccess(HttpMessageHandler messageHandler) => _messageHandler = messageHandler;

        public async Task<IResponse<Items>> TopStories()
        {
            IHackerNewsApi hackerNewsApi = RestService.For<IHackerNewsApi>(HostUrl, new RefitSettings { HttpMessageHandlerFactory = () => _messageHandler });

            try
            {
                return new Response<Items>(await hackerNewsApi.TopStories(), new ItemsAdapter());
            }
            catch (ApiException apiException)
            {
                return new Response<Items>(apiException);
            }
        }

        public async Task<IResponse<Item>> Item(ItemId itemId)
        {
            IHackerNewsApi hackerNewsApi = RestService.For<IHackerNewsApi>(HostUrl, new RefitSettings { HttpMessageHandlerFactory = () => _messageHandler });

            try
            {
                return new Response<Item>(await hackerNewsApi.Item(itemId.IdAsString()), new ItemAdapter());
            }
            catch (ApiException apiException)
            {
                return new Response<Item>(apiException);
            }
        }
    }
}
