using BlogManagementSystem.BL;
using BlogManagementSystem.Models.DTO;
using BlogManagementSystem.Models.Enum;
using BlogManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagementSystem.Controllers
{
    /// <summary>
    /// API Controller for managing Blog operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLBlogController : ControllerBase
    {
        private readonly IBLBLog _objBLBlog;
        private readonly ILogger<CLBlogController> _logger;
        private IResponse _objResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="CLBlogController"/> class.
        /// </summary>
        /// <param name="objBLBlog">Business logic instance for Blog.</param>
        /// <param name="logger">Logger instance for logging operations.</param>
        /// <param name="objResponse">Response object for handling API responses.</param>
        public CLBlogController(IBLBLog objBLBlog, ILogger<CLBlogController> logger, IResponse objResponse)
        {
            _objBLBlog = objBLBlog;
            _logger = logger;
            _objResponse = objResponse;
        }

        /// <summary>
        /// API endpoint to fetch all blog posts.
        /// </summary>
        /// <returns>List of all blog posts.</returns>
        [HttpGet]
        [Route("get-all-blogs")]
        public IActionResult GetAllBlogs(int pageSize = 10, int pageNumber = 1, string sorting = null)
        {
            _logger.LogInformation("Fetching all blog posts.");
            _objResponse = _objBLBlog.GetAllBlogs(pageSize, pageNumber, sorting);
            return Ok(_objResponse);
        }

        /// <summary>
        /// API endpoint to fetch a blog post by its ID.
        /// </summary>
        /// <param name="id">Blog post ID.</param>
        /// <returns>Blog post details.</returns>
        [HttpGet]
        [Route("get-blog-by-id")]
        public IActionResult GetBlogByID(int id)
        {
            _logger.LogInformation($"Fetching blog post with ID {id}.");
            _objResponse = _objBLBlog.GetBlogByID(id);
            return Ok(_objResponse);
        }

        /// <summary>
        /// API endpoint to delete a blog post by its ID.
        /// </summary>
        /// <param name="id">Blog post ID.</param>
        /// <returns>Response indicating the result of the deletion operation.</returns>
        [HttpDelete]
        [Route("delete-blog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _logger.LogInformation($"Deleting blog post with ID {id}.");
            _objResponse = _objBLBlog.Delete(id);  // Delete blog post and get response.
            return Ok(_objResponse);  // Return response message.
        }

        /// <summary>
        /// API endpoint to add a new blog post.
        /// </summary>
        /// <param name="objDTOBLG01">DTO object containing blog post details.</param>
        /// <returns>Response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("add-blog")]
        public IActionResult AddBlog(DTOBLG01 objDTOBLG01)
        {
            _logger.LogInformation("Creating a new blog post.");
            _objBLBlog.Type = EnmType.A;  // Set operation type to "Add".
            _objBLBlog.PreSave(objDTOBLG01);  // Prepare data for saving.
            _objResponse = _objBLBlog.ValidationSave();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBlog.Save();  // Save the new blog if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }

        /// <summary>
        /// API endpoint to update an existing blog post.
        /// </summary>
        /// <param name="objDTOBLG01">DTO object containing updated blog post details.</param>
        /// <returns>Response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("update-blog")]
        public IActionResult UpdateBlog(DTOBLG01 objDTOBLG01)
        {
            _logger.LogInformation($"Updating blog post with ID {objDTOBLG01.G01F01}.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return bad request if model state is invalid.
            }
            _objBLBlog.Type = EnmType.E;  // Set operation type to "Edit".
            _objBLBlog.PreSave(objDTOBLG01);  // Prepare data for saving.
            _objResponse = _objBLBlog.ValidationSave();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBlog.Save();  // Save the updated blog if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }
    }
}