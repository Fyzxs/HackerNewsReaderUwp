using System.Net.Http;
using System.Threading.Tasks;
using HackerNewsUwp.Network.Internal;
using Refit;

namespace HackerNewsUwp.Network
{
    public class HackerNewsAccess
    {
        private const string HostUrl = "http://quinngil.com";
        private static HttpMessageHandler _messageHandler;

        public HackerNewsAccess(){}

        public HackerNewsAccess(HttpMessageHandler messageHandler) => _messageHandler = messageHandler;

        public async Task<Response<Items>> TopStories()
        {
            IHackerNewsApi hackerNewsApi = RestService.For<IHackerNewsApi>(HostUrl, new RefitSettings {HttpMessageHandlerFactory = () => _messageHandler });

            try
            {
                return new Response<Items>(await hackerNewsApi.TopStories(), new ItemsAdapter());
            }
            catch (ApiException apiException)
            {
                return new Response<Items>(apiException);
            }
        }

        public async Task<Response<Item>> Item(ItemId itemId)
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
