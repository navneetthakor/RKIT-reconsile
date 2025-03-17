
using WebApplication1.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Business_Logic.Services;
using WebApplication1.Modals.Enums;
using WebApplication1.Modals.POCOs;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    /// contains all controllers related to admin
    /// </summary>
    public class AuthorController : ControllerBase
    {
        ///<summary>
        /// object for database connection
        /// </summary>
        private IDbConnection _connection;


        public AuthorController(IDatabaseService databaseService)
        {
            _connection = databaseService.db;
        }

        [HttpPost]
        [Route("Login")]
        /// <summary>
        /// for Author login
        /// <paramref name="email"> email </paramref>
        /// <paramref name="password"> password </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response AuthorLogin(string email, string password)
        {
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, null);
                Response resposne = authorLogics.Login(email, password);
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

        [HttpPost]
        [Route("AuthorRegister")]
        /// <summary>
        /// for Author Registration
        /// <paramref name="fdap01"> FDAP01 poco object </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response AuthorRegister([FromBody] FDAP01 fdap01)
        {
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, null);
                Response resposne = authorLogics.RegisterAuthor(fdap01);
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
        [Route("GetAllBooks")]
        /// <summary>
        /// Get all books of given user
        /// <paramref name="fdap01"> FDAP01 poco object </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, null);

                Response result = authorLogics.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = authorLogics.GetAllBooks(result.Data.A01F01);
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
        /// delete book of user (by book_id)
        /// <paramref name="bookId"> book id </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response DeleteBook(int bookId)
        {
            Response response = new Response();
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, null);

                Response result = authorLogics.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = authorLogics.PreDelete(bookId);
                if (result.IsError) throw new Exception(result.Message);

                result = authorLogics.ValidateOnDelete(result.Data.A01F01);
                if (result.IsError) throw new Exception(result.Message);

                result = authorLogics.Delete();
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

        [HttpPost]
        [Route("AddBook")]
        /// <summary>
        /// delete book of user (by book_id)
        /// <paramref name="fdap03"> FDAP03 poco object </paramref>
        /// <return>Response object</return>
        /// </summary>
        public Response AddBook(FDAP03 fdap03, int authorId)
        {
            Response response = new Response();
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, authorId);

                Response result = authorLogics.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not Author";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = authorLogics.PreSave(fdap03, OppEnum.A);
                if (result.IsError) throw new Exception(result.Message);

                result = authorLogics.ValidateOnSave(OppEnum.U);
                if (result.IsError) throw new Exception(result.Message);

                result = authorLogics.Save(OppEnum.A);
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
