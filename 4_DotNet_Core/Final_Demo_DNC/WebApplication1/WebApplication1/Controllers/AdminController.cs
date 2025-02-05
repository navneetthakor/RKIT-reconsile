using WebApplication1.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplication1.Business_Logic.Services;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IDbConnection _connection;
        public AdminController(IDatabaseService db)
        {
            _connection = db.db;
        }

        [HttpPost]
        [Route("Login")]
        public Response AdminLogin(string email, string password)
        {
            try
            {
                AdminLogics al = new AdminLogics(_connection, null);
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

    }
}
