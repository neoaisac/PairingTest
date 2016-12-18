using System;
using System.Net.Http;

namespace PairingTest.Web.Middleware.Http
{
    /// <summary>
    /// A container/factory of <see cref="HttpClient"/> instances bound to their specific base API addresses.
    /// </summary>
    /// <remarks>
    /// It is a known fact that the instantiation and destruction multiple times (as in a per-request
    /// basis) of the <see cref="HttpClient"/> class can result in memory leakage and performance
    /// issues. The usage of a container/factory in a per-application scenario ensures that a single
    /// instance of each <see cref="HttpClient"/> is generated and reused in all requests, which is
    /// more efficient and less prone to issues.
    /// </remarks>
    public interface IHttpClientContainer
    {
        /// <summary>
        /// Gets or generates a new instance of <see cref="HttpClient"/> for each given
        /// <paramref name="baseAddress"/> and keeps it in context for future use.
        /// </summary>
        /// <param name="baseAddress">
        /// The base address of the external API the <see cref="HttpClient"/> instance is bound to.
        /// </param>
        /// <returns>An instance of <see cref="HttpClient"/> bound to the specific <paramref name="baseAddress"/>.</returns>
        HttpClient Get(Uri baseAddress);
    }
}