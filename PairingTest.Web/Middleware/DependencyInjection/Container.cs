using System.Configuration;
using PairingTest.Web.Controllers;
using PairingTest.Web.Middleware.Http;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace PairingTest.Web.Middleware.DependencyInjection
{
    internal class Container : SimpleInjector.Container
    {
        public Container()
        {
            Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register scoped (per-request) singletons

            // Register application-wide singletons
            Register<IHttpClientContainer, HttpClientContainer>(Lifestyle.Singleton);

            // Register transients

            // Register standalone initializers
            RegisterInitializer<QuestionnaireController>(x => { x.QuestionnaireServiceUri = ConfigurationManager.AppSettings["QuestionnaireServiceUri"]; });

            // Extensions
            this.RegisterMvcControllers();
        }
    }
}