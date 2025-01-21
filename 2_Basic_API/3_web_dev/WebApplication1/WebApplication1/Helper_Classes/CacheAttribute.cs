using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace WebApplication1.Helper_Classes
{
    public class CacheAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(1000),
                MustRevalidate = true,
                Public = false, // tells no intermediate should case this resource
                Private = true, // tells that message response is indented for end user only (no intermediate cache)
            };
        }
    }
}