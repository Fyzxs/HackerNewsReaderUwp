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
    public class Response<T> where T : class
    {
        private readonly INetworkAdapter<T> _adapter;
        private HttpStatusCode _statusCode;
        private string _content;

        public Response(HttpResponseMessage rawHttpResponseMessage, INetworkAdapter<T> adapter, ApiException apiException)
        {
            _adapter = adapter;
            if (rawHttpResponseMessage != null)
            {
                _adapter = adapter;
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

        public T Body()
        {
            if (_content == null) return null;

            return _adapter == null ? JsonConvert.DeserializeObject<T>(_content) : _adapter.FromRawContent(_content);
        }
    }
}
