using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HackerNewsUwp.Network.Internal;
using Newtonsoft.Json;
using Refit;

namespace HackerNewsUwp.Network
{
    public class Response
    {
        private HttpStatusCode _statusCode;
        private string _content;

        public Response(HttpResponseMessage rawHttpResponseMessage, ApiException apiException)
        {
            if (rawHttpResponseMessage != null)
            {
                ParseHttpResponseMessage(rawHttpResponseMessage);
            }
            else if (apiException != null)
            {
                ParseApiException(apiException);
            }
            else
            {
                throw new NullReferenceException("raw Response is null");
            }
        }

        private void ParseApiException(ApiException apiException)
        {
            _statusCode = apiException.StatusCode;
            _content = apiException.Content;
        }

        private void ParseHttpResponseMessage(HttpResponseMessage rawHttpResponseMessage)
        {
            _statusCode = rawHttpResponseMessage.StatusCode;
            _content = rawHttpResponseMessage.Content?.ReadAsStringAsync().Result;
        }

        public HttpStatusCode StatusCode()
        {
            return _statusCode;
        }

        public string Message()
        {
            return _content;
        }

        public ItemJson Body()
        {
            return _content == null ? null : JsonConvert.DeserializeObject<ItemJson>(_content);
        }
    }
}
