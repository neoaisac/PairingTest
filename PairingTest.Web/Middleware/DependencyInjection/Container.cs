using PairingTest.Web.Middleware.Http;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace PairingTest.Web.Middleware.DependencyInjection
{
    internal class Container : SimpleInjector.Container
    {
        public Container()
        {
            // Register application-wide singletons
            Register<IHttpClientContainer, HttpClientContainer>(Lifestyle.Singleton);

            // Register scoped (per-request) singletons
            Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register transients
        }
    }
}