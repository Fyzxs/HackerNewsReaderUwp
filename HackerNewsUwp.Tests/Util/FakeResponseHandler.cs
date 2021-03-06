﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsUwp.Tests.Util
{
    public class FakeResponseHandler : DelegatingHandler
    {
        //URI
        //HttpResponseMessage
        //Headers
        //Response Delay
        private readonly
            List<Tuple<Uri, HttpResponseMessage, List<KeyValuePair<string, IEnumerable<string>>>, TimeSpan>>
            _fakeResponses =
                new List<Tuple<Uri, HttpResponseMessage, List<KeyValuePair<string, IEnumerable<string>>>, TimeSpan>>();


        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            AddFakeResponse(uri, responseMessage, new List<KeyValuePair<string, IEnumerable<string>>>(), new TimeSpan());
        }

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage,
            List<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            AddFakeResponse(uri, responseMessage, headers, new TimeSpan());
        }

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage, TimeSpan timeSpan)
        {
            AddFakeResponse(uri, responseMessage, new List<KeyValuePair<string, IEnumerable<string>>>(), timeSpan);
        }

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage,
            List<KeyValuePair<string, IEnumerable<string>>> headers, TimeSpan timeSpan)
        {
            _fakeResponses.Add(
                new Tuple<Uri, HttpResponseMessage, List<KeyValuePair<string, IEnumerable<string>>>, TimeSpan>(uri,
                    responseMessage, headers, timeSpan));
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            foreach (Tuple<Uri, HttpResponseMessage, List<KeyValuePair<string, IEnumerable<string>>>, TimeSpan>
                fakeResponse in _fakeResponses)
            {
                if (!fakeResponse.Item1.Equals(request.RequestUri)) continue;

                if (!fakeResponse.Item3.Any()) return Task.FromResult(fakeResponse.Item2);

                if (HasHeaders(request, fakeResponse)) continue;

                return fakeResponse.Item4.Equals(TimeSpan.Zero)
                    ? Task.FromResult(fakeResponse.Item2)
                    : Task.FromException<HttpResponseMessage>(new TimeoutException());
            }

            List<string> handledUrls = _fakeResponses.Aggregate(new List<string>(), (all, item) => {
                    all.Add(item.Item1.ToString());
                    return all;
                });

            throw new Exception($"{request.RequestUri} not matched in {string.Join(",", handledUrls)}");
        }

        private static bool HasHeaders(HttpRequestMessage request,
            Tuple<Uri, HttpResponseMessage, List<KeyValuePair<string, IEnumerable<string>>>, TimeSpan> fakeResponse)
        {
            bool hasHeaders = true;
            foreach (KeyValuePair<string, IEnumerable<string>> header in fakeResponse.Item3)
            {
                if (!request.Headers.TryGetValues(header.Key, out IEnumerable<string> values))
                {
                    foreach (string value in header.Value)
                    {
                        // ReSharper disable once PossibleMultipleEnumeration
                        if (!values.Contains(value))
                        {
                            hasHeaders = false;
                        }
                    }
                }
                else
                {
                    hasHeaders = false;
                }
            }

            return !hasHeaders;
        }
    }
}