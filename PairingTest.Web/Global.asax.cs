using System.Web.Mvc;
using System.Web.Routing;
using PairingTest.Web.App_Start;
using PairingTest.Web.Middleware.DependencyInjection;
using SimpleInjector.Integration.Web.Mvc;

namespace PairingTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(new Container()));
        }
    }
}