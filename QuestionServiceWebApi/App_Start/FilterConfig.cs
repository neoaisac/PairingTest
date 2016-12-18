using System.Web.Http.Filters;
using QuestionServiceWebApi.Middleware.ExceptionHandling;

namespace QuestionServiceWebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new GlobalExceptionFilterAttribute());
        }
    }
}