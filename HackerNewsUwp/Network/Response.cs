﻿using HackerNewsUwp.Network.Internal;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net;
using System.Net.Http;

namespace HackerNewsUwp.Network
{
    public interface IResponse<out T> where T : class
    {
        HttpStatusCode StatusCode();
        string Message();
        T Body();
    }

    public class Response<T> : IResponse<T> where T : class
    {
        private readonly INetworkAdapter<T> _adapter;
        private HttpStatusCode _statusCode;
        private string _content;

        public Response(HttpResponseMessage rawHttpResponseMessage, INetworkAdapter<T> adapter)
        {
            if (rawHttpResponseMessage == null) throw new NullReferenceException("raw Response is null");

            _adapter = adapter;
            ParseHttpResponseMessage(rawHttpResponseMessage);

        }
        public Response(ApiException apiException)
        {
            if (apiException == null) throw new NullReferenceException("raw Response is null");

            ParseApiException(apiException);
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
