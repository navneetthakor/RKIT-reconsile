using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Code to run before the resource is processed
            Debug.WriteLine("Resource executing...");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Code to run after the resource is processed
            Debug.WriteLine("Resource executed...");
        }
    }
}
