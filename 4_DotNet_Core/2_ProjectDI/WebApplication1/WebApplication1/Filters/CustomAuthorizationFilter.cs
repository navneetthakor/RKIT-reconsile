using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.Filters
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine("Authorization filter");
        }
    }
}
