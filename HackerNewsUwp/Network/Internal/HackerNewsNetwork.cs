using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace HackerNewsUwp.Network
{
    public class HackerNewsNetwork
    {
        private const string HostUrl = "http://blog.quantityandconversion.com";
        private static HttpMessageHandler _messageHandler = null;

        public HackerNewsNetwork(){}

        public HackerNewsNetwork(HttpMessageHandler messageHandler)
        {
            //should check for debug so it can be taken out in some kinda proguard?
            _messageHandler = messageHandler;
        }


        public Task<string> TopStories()
        {
            IHackerNewsApi hackerNewsApi = RestService.For<IHackerNewsApi>(HostUrl,
                new RefitSettings() {HttpMessageHandlerFactory = () => _messageHandler });
            return hackerNewsApi.TopStories();
        }
    }
}
