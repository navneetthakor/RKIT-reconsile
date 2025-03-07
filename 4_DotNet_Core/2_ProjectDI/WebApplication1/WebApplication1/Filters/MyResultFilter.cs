using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Result Filter executing"); ;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Result Filter executed"); ;
        }
    }
}
