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


        public AdminController(IDatabaseService db)
        {
            _connection = db.db;
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
                AdminLogics al = new AdminLogics(_connection, null);
                Response resposne = al.Login(email, password);
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
        public Response GetAllAuthors()
        {
            Response response = new Response();
            try
            {
                AdminLogics al = new AdminLogics(_connection, null);

                    Response result = al.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = al.GetAllAuthors();
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
        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                AdminLogics al = new AdminLogics(_connection, null);

                Response result = al.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = al.GetAllBooks();
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
        public Response DeleteAuthor(int Author_id)
        {
            Response response = new Response();
            try
            {
                AdminLogics al = new AdminLogics(_connection, null);

                Response result = al.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = al.PreDelete(Author_id, WOBEnum.Author);
                if (result.IsError) throw new Exception(result.Message);

                result = al.ValidateOnDelete(WOBEnum.Author);
                if (result.IsError) throw new Exception(result.Message);

                result = al.Delete(WOBEnum.Author);
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
        public Response DeleteBook(int Book_id)
        {
            Response response = new Response();
            try
            {
                AdminLogics al = new AdminLogics(_connection, null);

                Response result = al.IsAdmin(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = al.PreDelete(Book_id, WOBEnum.Book);
                if (result.IsError) throw new Exception(result.Message);

                result = al.ValidateOnDelete(WOBEnum.Book);
                if (result.IsError) throw new Exception(result.Message);

                result = al.Delete(WOBEnum.Book);
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
