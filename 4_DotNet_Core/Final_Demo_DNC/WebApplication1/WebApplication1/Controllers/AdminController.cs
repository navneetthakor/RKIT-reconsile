using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using ServiceStack.OrmLite;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApplication1.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/admin/[controller]")]
    [ApiController]
    internal class AdminController : ControllerBase
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
            Response response = new Response();
            try
            {

                FDAP01? currentUser = _connection.Single<FDAP01>(x => x.A01F03 == email);
                if (currentUser == null)
                {
                    response.IsError = true;
                    response.Message = "Admin with given email not exists";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }

                FDAP02 isItAdmin = _connection.Single<FDAP02>(x => x.A02F01 == currentUser.A01F01);
                if (isItAdmin.A02F02 != 0 || currentUser.A01F04 != password)
                {
                    response.IsError = true;
                    response.Message = "Password is not valid or You are not admin";
                    response.StatusCode = MyStatusCodes.Unauthorized;
                    return response;
                }



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
