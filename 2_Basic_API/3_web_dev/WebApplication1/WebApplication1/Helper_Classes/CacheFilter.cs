using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace WebApplication1.Helper_Classes
{
    public class CacheFilter : ActionFilterAttribute
    {


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(1000),
                MustRevalidate = true,
                Public = true
            };
        }
    }
}