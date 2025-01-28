using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDotNetCore.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {

        [Route("/Hello")]
        [HttpGet]
        public string GetHello()
        {
            return "Hello";
        }
    }
}
