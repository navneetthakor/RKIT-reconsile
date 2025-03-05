using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    /// uses signle product repo for read and write
    /// </summary>
    public class ValuesController : ControllerBase
    {
        IProductRepo _prodRepo;
        public ValuesController(IProductRepo prodRepo) 
        {   
            _prodRepo = prodRepo;
        }

        [Route("AddProduct")]
        [HttpPost]
        /// <summary>
        /// add product to product repo
        /// </summary>
        public IActionResult AddProduct([FromBody] string title)
        {
            _prodRepo.AddProd(title);
            return Ok(_prodRepo.lstProd);
        }

        [Route("CheckError")]
        [HttpGet]
        ///<summary>
        /// to throw error (used in exception handler page)
        /// </summary>
        public IActionResult CheckError()
        {
            throw new Exception("my Sample Error");
            //return Ok("done");
        }
    }
}

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    /// uses multiple product repo for read and write
    /// </summary>
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
        ///<summary>
        /// adding product to second repo
        /// </summary>
        public IActionResult AddProduct([FromBody] string title)
        {
            _prodRepo1.AddProd(title);
            return Ok(_prodRepo2.lstProd);
        }
    }
}