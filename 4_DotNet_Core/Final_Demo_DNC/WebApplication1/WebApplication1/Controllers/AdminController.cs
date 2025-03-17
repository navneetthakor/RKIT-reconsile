using WebApplication1.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Business_Logic.Services;
using WebApplication1.Modals.Enums;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    /// contains all controllers related to admin
    /// </summary>
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// for database connection
        /// </summary>
        private IDbConnection _connection;


        public AdminController(IDatabaseService databaseService)
        {
            _connection = databaseService.db;
        }


        [HttpPost]
        [Route("Login")]
        /// <summary>
        /// for admin login
        /// <paramref name="logger"> nlogger object </paramref>
        /// <paramref name="email"> email </paramref>
        /// <paramref name="password"> password </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response AdminLogin(ILogger<AdminController> logger ,string email, string password)
        {
            try
            {
                AdminLogics adminLogics = new AdminLogics(_connection, null);
                Response resposne = adminLogics.Login(email, password);
                logger.LogInformation("Admin loggin event");
                return resposne;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.IsError = true;
                response.Message = ex.Message;
                response.StatusCode = MyStatusCodes.Internal_server_Error;
                return response;
            }
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        /// <summary>
        /// Get all authors
        /// <return>Response object</return>
        /// </summary>
        public Response GetAllAuthors()
        {
            Response response = new Response();
            try
            {
                AdminLogics adminLogics = new AdminLogics(_connection, null);

                    Response result = adminLogics.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = adminLogics.GetAllAuthors();
                response.StatusCode = MyStatusCodes.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                response.StatusCode = MyStatusCodes.Internal_server_Error;
                return response;
            }
        }

        [HttpGet]
        [Route("GetAllBooks")]
        /// <summary>
        /// get all books with corresponding Author
        /// <return>Response object</return>
        /// </summary>
        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                AdminLogics adminLogics = new AdminLogics(_connection, null);

                Response result = adminLogics.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = adminLogics.GetAllBooks();
                response.StatusCode = MyStatusCodes.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                response.StatusCode = MyStatusCodes.Internal_server_Error;
                return response;
            }
        }

        [HttpDelete]
        [Route("DeleteAuthor")]
        /// <summary>
        /// Delete auther by id
        /// <paramref name="authorId"> Author Id </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response DeleteAuthor(int authorId)
        {
            Response response = new Response();
            try
            {
                AdminLogics adminLogics = new AdminLogics(_connection, null);

                Response result = adminLogics.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = adminLogics.PreDelete(authorId, WOBEnum.Author);
                if (result.IsError) throw new Exception(result.Message);

                result = adminLogics.ValidateOnDelete(WOBEnum.Author);
                if (result.IsError) throw new Exception(result.Message);

                result = adminLogics.Delete(WOBEnum.Author);
                if (result.IsError) throw new Exception(result.Message);

                response.Data = 1;
                response.Message = result.Message;
                response.StatusCode = MyStatusCodes.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                response.StatusCode = MyStatusCodes.Internal_server_Error;
                return response;
            }
        }


        [HttpDelete]
        [Route("DeleteBook")]
        /// <summary>
        /// Delete auther by id
        /// <paramref name="bookId"> Book Id </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response DeleteBook(int bookId)
        {
            Response response = new Response();
            try
            {
                AdminLogics adminLogics = new AdminLogics(_connection, null);

                Response result = adminLogics.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = adminLogics.PreDelete(bookId, WOBEnum.Book);
                if (result.IsError) throw new Exception(result.Message);

                result = adminLogics.ValidateOnDelete(WOBEnum.Book);
                if (result.IsError) throw new Exception(result.Message);

                result = adminLogics.Delete(WOBEnum.Book);
                if (result.IsError) throw new Exception(result.Message);

                response.Data = 1;
                response.Message = result.Message;
                response.StatusCode = MyStatusCodes.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                response.StatusCode = MyStatusCodes.Internal_server_Error;
                return response;
            }
        }
    }
}
