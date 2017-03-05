using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            foreach (var fakeResponse in _fakeResponses)
            {
                if (!fakeResponse.Item1.Equals(request.RequestUri)) continue;

                if (!fakeResponse.Item3.Any()) return Task.FromResult(fakeResponse.Item2);

                var hasHeaders = true;
                foreach (var header in fakeResponse.Item3)
                {
                    IEnumerable<string> values;
                    if (request.Headers.TryGetValues(header.Key, out values))
                    {
                        foreach (var value in header.Value)
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

                if (!hasHeaders) continue;
                return fakeResponse.Item4.Equals(TimeSpan.Zero)
                    ? Task.FromResult(fakeResponse.Item2)
                    : Task.FromException<HttpResponseMessage>(new TimeoutException());
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound) {RequestMessage = request});
        }
    }
}