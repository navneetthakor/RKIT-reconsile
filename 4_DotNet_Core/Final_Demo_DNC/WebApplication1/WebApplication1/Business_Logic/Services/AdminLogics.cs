using System;
using System.Data;
using System.Data.Common;
using WebApplication1.Business_Logic.Interfaces;
using WebApplication1.Modals.Enums;
using WebApplication1.Modals.POCOs;
using WebApplication1.Utilitlies;
using ServiceStack;
using ServiceStack.OrmLite;

namespace WebApplication1.Business_Logic.Services
{
    internal class AdminLogics : IDbDeleteAdmin
    {
        private IDbConnection _dbConnection;
        public FDAP01 _admin; // temporory public
        private FDAP01 _fdap01;
        private FDAP03 _fdap03;

        public AdminLogics(IDbConnection dbConnection, FDAP01? admin)
        {
            _dbConnection = dbConnection;
            _admin = admin;
        }

        public Response Login(string email, string password)
        {
            Response response = new Response();

            FDAP01? currentUser = _dbConnection.Single<FDAP01>(x => x.A01F03 == email);
            if (currentUser == null)
            {
                response.IsError = true;
                response.Message = "Admin with given email not exists";
                response.StatusCode = MyStatusCodes.Unauthorized;
                return response;
            }

            FDAP02 isItAdmin = _dbConnection.Single<FDAP02>(x => x.A02F01 == currentUser.A01F01);
            if (isItAdmin.A02F02 != 0 || currentUser.A01F04 != password)
            {
                response.IsError = true;
                response.Message = "Password is not valid or You are not admin";
                response.StatusCode = MyStatusCodes.Unauthorized;
                return response;
            }

            response.Message = "Admin Login completed";
            response.StatusCode = MyStatusCodes.Success;
            response.Data = currentUser;
            return response;

        }


        /// <summary>
        /// Predelete method creates corresponding POCO class for given 
        /// id and type of object to be deleted
        /// </summary>
        /// <param name="id">Id of Author or Book</param>
        /// <param name="typeOfDelete">Auther or Book</param>
        /// <returns>Response Object</returns>
        public Response PreDelete(int id, WOBEnum typeOfDelete)
        {
            Response response = new Response();
            try
            {
                if (typeOfDelete == WOBEnum.Author)
                {
                    _fdap01 = new FDAP01() { A01F01 = id };
                }
                else
                {
                    _fdap03 = new FDAP03() { A03F01 = id };
                }

                response.Message = "PreDelete Completed";
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                Console.WriteLine("Exception : " + ex.Message);
                return response;
            }
        }


        /// <summary>
        /// it validates that whether entry corresponding to the given id is exists in DB or not.
        /// </summary>
        /// <param name="typeOfDelete">Auther or Book</param>
        /// <returns>Response</returns>
        public Response ValidateOnDelete(WOBEnum typeOfDelete)
        {

            Response response = new Response();
            try
            {
                if (typeOfDelete == WOBEnum.Author)
                {
                    if (_dbConnection.Select<FDAP01>(x => x.A01F01 == _fdap01.A01F01) == null)
                        throw new Exception("Entry not exist in DB");
                }
                else
                {
                    if (_dbConnection.Select<FDAP03>(x => x.A03F01 == _fdap03.A03F01) == null)
                        throw new Exception("Entry not exist in DB");
                }

                response.Message = "PreDelete Completed";
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                Console.WriteLine("Exception : " + ex.Message);
                return response;
            }
        }

        /// <summary>
        /// This method finally deletes the desired object from database
        /// </summary>
        /// <param name="typeOfDelete">Auther || Book</param>
        /// <returns>Response Object</returns>
        public Response Delete(WOBEnum typeOfDelete)
        {

            Response response = new Response();
            try
            {
                if (typeOfDelete == WOBEnum.Author)
                {
                    response.Data = _dbConnection.Select<FDAP01>(x => x.A01F01 == _fdap01.A01F01);
                    _dbConnection.DeleteById<FDAP01>(_fdap01.A01F01);
                }
                else
                {
                    response.Data = _dbConnection.Select<FDAP03>(x => x.A03F01 == _fdap03.A03F01);
                    _dbConnection.DeleteById<FDAP03>(_fdap03.A03F01);
                }

                response.Message = "Deleted Entry";
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                Console.WriteLine("Exception : " + ex.Message);
                return response;
            }
        }

        /// <summary>
        /// Fetches all the books from table
        /// </summary>
        /// <returns></returns>
        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                List<FDAP01> l1 = _dbConnection.Select<FDAP01>();
                List<FDAP03> l2 = _dbConnection.Select<FDAP03>();
                response.Data = l1.Join(l2, l1 => l1.A01F01, l2 => l2.A03F04, (a, b) => new { a, b })
                    .ToList();

                response.Message = "All books are Fetched";
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                Console.WriteLine("Exception : " + ex.Message);
                return response;
            }
        }

        public Response GetAllAuthors()
        {
            Response response = new Response();
            try
            {

                List<FDAP01> l1 = _dbConnection.Select<FDAP01>();
                List<FDAP02> l2 = _dbConnection.Select<FDAP02>();
                response.Data = l1.Join(l2, l1 => l1.A01F01, l2 => l2.A02F01, (a, b) => new { a, b })
                    .Where(x => x.b.A02F02 == A02F01Values.Author)
                    .ToList();
                response.Message = "All Authors are Fetched";
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                Console.WriteLine("Exception : " + ex.Message);
                return response;
            }
        }


    }
}
