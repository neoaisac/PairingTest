using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PairingTest.Web.Middleware.Http
{
    /// <summary>
    /// A container/factory that keeps a singleton <see cref="HttpClient"/> object per API Uri.
    /// </summary>
    public class HttpClientContainer : IHttpClientContainer
    {
        private readonly IDictionary<Uri, HttpClient> _innerCollection = new Dictionary<Uri, HttpClient>();

        /// <inheritdoc/>
        public HttpClient Get(Uri baseAddress)
        {
            if (!_innerCollection.ContainsKey(baseAddress))
                _innerCollection.Add(baseAddress, new HttpClient { BaseAddress = baseAddress });

            return _innerCollection[baseAddress];
        }
    }
}