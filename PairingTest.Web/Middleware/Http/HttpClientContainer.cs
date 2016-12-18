﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

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
            throw new NotImplementedException();
        }
    }
}