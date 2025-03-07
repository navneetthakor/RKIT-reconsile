using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.Filters
{
    public class MyActionfilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action executing.");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action executed.");
        }

    }
}
