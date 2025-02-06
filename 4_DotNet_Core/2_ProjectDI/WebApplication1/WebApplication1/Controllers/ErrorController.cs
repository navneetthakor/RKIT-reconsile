using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/Error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            Console.WriteLine("----------------Hello nk---------------");

            var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(title: exceptionHandlerFeature.Error.Message);
        }

    }

}
