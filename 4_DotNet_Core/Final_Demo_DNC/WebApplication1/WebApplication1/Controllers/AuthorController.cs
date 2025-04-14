
using WebApplication1.Utilitlies;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Business_Logic.Services;
using WebApplication1.Modals.Enums;
using WebApplication1.Modals.POCOs;
using System.Data.Common;
using ServiceStack.OrmLite;
using ServiceStack;
using System.Diagnostics;
using System.Linq;
using Mysqlx.Crud;

namespace WebApplication1.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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

        [HttpPost("Login")]
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

        [HttpPost("AuthorRegister")]
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

        [HttpGet("GetAllBooks")]
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

        [HttpGet("GetAllBooks2")]
        /// <summary>
        /// Get all books of given user
        /// using for JTable Demo
        /// </summary>
        public Response GetAllBooks2(int skip, int take, string? sortFeild, int? sortType)
        {
            Response response = new Response();
            try
            {
                List<FDAP03> lst = _connection.Select<FDAP03>(x => x.A03F04 == 2);
                long totalCnt = lst.Count;
                if (skip != -1)
                {
                    lst = lst.Skip(skip).Take(take).ToList();
                    Debug.WriteLine(skip + " , " + take);
                }
                if(sortFeild != null)
                {
                    if (sortType == 1)
                        if(sortFeild == "a03F01")
                            lst = lst.OrderBy(e => e.A03F01).ToList();
                        else
                            lst = lst.OrderBy(e => e.A03F02).ToList();
                    else
                        if(sortFeild == "a03F01")
                            lst = lst.OrderByDescending(e => e.A03F01).ToList();
                        else
                            lst = lst.OrderByDescending(e => e.A03F02).ToList();


                    Debug.WriteLine("sorting : " + sortFeild + " , " + sortType);
                }
                response.Data= new { items = lst, totalCount = totalCnt };
                
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


        [HttpDelete("DeleteBook")]
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

        [HttpDelete("DeleteBook2")]
        /// <summary>
        /// delete book of user (by book_id)
        /// used in JTable demo
        /// </summary>
        public Response DeleteBook2(int a03F01)
        {
            Response response = new Response();
            try
            {
                AuthorLogics authorLogics = new AuthorLogics(_connection, null);

                int result = _connection.DeleteById<FDAP03>(a03F01);

                response.Data = 1;
                response.Message = "Success full";
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

        [HttpPost("AddBook")]
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


        [HttpPost("AddBook2")]
        /// <summary>
        /// Add book of author
        /// using in JTable demo
        /// </summary>
        public Response AddBook2(string a03F02, string a03F03)
        {
            Response response = new Response();
            try
            {
                FDAP03 fdap03 = new FDAP03() {
                    A03F03 = a03F03,
                    A03F02 = a03F02,
                    A03F04 = 2
                };

                Debug.WriteLine(fdap03.A03F02);
                long result = _connection.Insert(fdap03);
                


                response.Data = 1;
                response.Message = "Record added";
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

        [HttpPut("UpdateBook2")]
        /// <summary>
        /// Add book of author
        /// using in JTable demo
        /// </summary>
        public Response UpdateBook2(int a03F01, string a03F02, string a03F03)
        {
            Response response = new Response();
            try
            {
                FDAP03 fdap03 = new FDAP03()
                {
                    A03F01 = a03F01,
                    A03F03 = a03F03,
                    A03F02 = a03F02,
                    A03F04 = 2
                };
                Debug.WriteLine(fdap03.A03F02);
                long result = _connection.Update(fdap03);

                response.Data = 1;
                response.Message = "Record added";
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
