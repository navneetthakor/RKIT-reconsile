using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IProductRepo _prodRepo;
        public ValuesController(IProductRepo prodRepo) 
        {   
            _prodRepo = prodRepo;
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] string title)
        {
            _prodRepo.AddProd(title);
            return Ok(_prodRepo.lstProd);
        }

        [Route("CheckError")]
        [HttpGet]
        public IActionResult CheckError()
        {
            throw new Exception("my Sample Error");
            return Ok("done");
        }
    }
}

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        IProductRepo _prodRepo1;
        IProductRepo _prodRepo2;
        public Values2Controller(IProductRepo prodRepo, IProductRepo prodRepo2)
        {
            _prodRepo1 = prodRepo;
            _prodRepo2 = prodRepo2;
        }

        [Route("AddProduct2")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] string title)
        {
            _prodRepo1.AddProd(title);
            return Ok(_prodRepo2.lstProd);
        }
    }
}