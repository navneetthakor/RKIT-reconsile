
using WebApplication1.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Business_Logic.Services;
using WebApplication1.Modals.Enums;
using WebApplication1.Modals.POCOs;
using WebApplication1.Modals.DTOs;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IDbConnection _connection;
        public AuthorController(IDatabaseService db)
        {
            _connection = db.db;
        }

        [HttpPost]
        [Route("Login")]
        public Response AuthorLogin(string email, string password)
        {
            try
            {
                AuthorLogics al = new AuthorLogics(_connection, null);
                Response resposne = al.Login(email, password);
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
        public Response AuthorRegister([FromBody] FDAP01 fdap01)
        {
            try
            {
                AuthorLogics al = new AuthorLogics(_connection, null);
                Response resposne = al.RegisterAuthor(fdap01);
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
        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                AuthorLogics al = new AuthorLogics(_connection, null);

                Response result = al.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                response = al.GetAllBooks(result.Data.A01F01);
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
                AuthorLogics al = new AuthorLogics(_connection, null);

                Response result = al.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = al.PreDelete(Book_id);
                if (result.IsError) throw new Exception(result.Message);

                result = al.ValidateOnDelete(result.Data.A01F01);
                if (result.IsError) throw new Exception(result.Message);

                result = al.Delete();
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
        [Route("AddBook")]
        public Response AddBook(FDAP03 fdap03)
        {
            Response response = new Response();
            try
            {
                AuthorLogics al = new AuthorLogics(_connection, null);

                Response result = al.IsAuthor(User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                if (result.IsError)
                {
                    response.IsError = true;
                    response.Message = "you are not Author";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                result = al.PreSave(fdap03, OppEnum.A);
                if (result.IsError) throw new Exception(result.Message);

                result = al.ValidateOnSave(OppEnum.U);
                if (result.IsError) throw new Exception(result.Message);

                result = al.Save(OppEnum.A);
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
