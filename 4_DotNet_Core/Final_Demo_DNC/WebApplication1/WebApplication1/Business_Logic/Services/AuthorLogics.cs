using WebApplication1.Business_Logic.Interfaces;
using WebApplication1.Modals.POCOs;
using WebApplication1.Utilitlies;
using System.Data;
using System;
using WebApplication1.Modals.DTOs;
using WebApplication1.Modals.Enums;
using ServiceStack.OrmLite;

namespace WebApplication1.Business_Logic.Services
{
    internal class AuthorLogics : IDbAddOppar, IDbDeleteOppar
    {
        private IDbConnection _dbConnection;
        private FDAP03 _fdap03;
        private FDAP01 _fdap01;
        public AuthorLogics(IDbConnection dbConnection, FDAP01 fdap01)
        {
            _dbConnection = dbConnection;
            _fdap01 = fdap01;
        }

        public static Response RegisterAuthor(FDAP01 user, IDbConnection db)
        {
            Response response = new Response();
            //check user with same email exists or not 
            bool isUserAxists = db.Exists<FDAP01>(x => x.A01F03 == user.A01F03);
            if (isUserAxists)
            {
                response.Message = "User with same email already exists";
                response.IsError = true;
                return response;
            }

            bool Authersaved = db.Save(user);
            if (Authersaved)
            {
                db.Insert(new FDAP02() { A02F01 = user.A01F01, A02F02 = A02F01Values.Author });
            }
            else
            {
                response.Message = "Internal server error while registering user";
                response.IsError = true;
                return response;
            }

            response.Message = "User registration successful";
            return response;
        }

        /// <summary>
        /// Presave for : adding or updating entry in the database
        /// </summary>
        /// <param name="dtofdap03">input dto that we are getting</param>
        /// <returns>Response object</returns>
        public Response PreSave(FDAP03 fdap03, OppEnum AOU)
        {
            Response response = new Response();
            try
            {
                _fdap03 = new FDAP03();

                _fdap03.A03F02 = fdap03.A03F02; // title of book
                _fdap03.A03F03 = fdap03.A03F03; // desc of book
                _fdap03.A03F04 = _fdap01.A01F01; // id of author
                if (AOU == OppEnum.U)
                {
                    _fdap03.A03F01 = fdap03.A03F01;
                }
                response.Message = "Presave done";
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
        /// Validates that entry of the object is pressent or not in DB
        /// Add opertion : count == 0
        /// update operation : count == 1
        /// </summary>
        /// <param name="AOU">Add or Update</param>
        /// <returns>Response</returns>
        public Response ValidateOnSave(OppEnum AOU)
        {
            Response response = new Response();
            try
            {
                if (AOU == OppEnum.A)
                {

                    //List<FDAP03> lst = _dbConnection.Select<FDAP03>($"select * from fdap03 where A03F02 = {_fdap03.A03F02} and A03F04 = {_fdap01.A01F01}");
                    List<FDAP03> lst = _dbConnection.Select<FDAP03>(x => x.A03F02 == _fdap03.A03F02 && x.A03F04 == _fdap01.A01F01);

                    if (lst.Count != 0) throw new Exception("Book with same title exists for current Author");
                }
                else
                {
                    // checking with id becasue use can't update id
                    //List<FDAP03> lst = _dbConnection.Select<FDAP03>($"select * from fdap03 where A03F01 = {_fdap03.A03F01} and A03F04 = {_fdap01.A01F03}");
                    List<FDAP03> lst = _dbConnection.Select<FDAP03>(x => x.A03F01 == _fdap03.A03F01 && x.A03F04 == _fdap01.A01F01);
                    if (lst.Count == 0) throw new Exception("Book with given id not exists for current Author");
                }
                response.Message = "Presave done";
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
        /// This method finally saves updates to the database
        /// </summary>
        /// <param name="AOU">Add or Update</param>
        /// <returns>Response object</returns>
        public Response Save(OppEnum AOU)
        {
            Response response = new Response();
            try
            {
                if (AOU == OppEnum.A)
                {
                    var result = _dbConnection.Insert(_fdap03);
                    if (result == 0) throw new Exception("Book with same title exists for current Author");
                }
                else
                {
                    // checking with id becasue use can't update id
                    var result = _dbConnection.Update(_fdap03);
                    if (result == 0) throw new Exception("Book with given id not exists for current Author");
                }
                response.Message = "Presave done";
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

        // Delete operation related ---------------
        /// <summary>
        /// PreDelete performs transformation from Dto (or non POcoc) to Poco
        /// </summary>
        /// <param name="id">id of book that Auther wants to delete (his own book only)</param>
        /// <returns>Response Object</returns>
        public Response PreDelete(int id)
        {
            Response response = new Response();
            try
            {
                _fdap03 = new FDAP03();
                _fdap03.A03F01 = id;

                response.Message = "PreDelete done";
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
        /// Performs validation checks that corresponding book exists in Database which Author wants to delete.
        /// </summary>
        /// <returns>Response Object</returns>
        public Response ValidateOnDelete()
        {
            Response response = new Response();
            try
            {
                List<FDAP03> lst = _dbConnection.Select<FDAP03>(x => x.A03F01 == _fdap03.A03F01 && x.A03F04 == _fdap01.A01F01);
                if (lst.Count == 0) throw new Exception("Book with given id not exists for current Author");

                response.Message = "ValidateOnDelete done";
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
        /// This method finally deletes the entry from Database 
        /// </summary>
        /// <returns></returns>
        public Response Delete()
        {
            Response response = new Response();
            try
            {
                int result = _dbConnection.DeleteById<FDAP03>(_fdap03.A03F01);
                if (result != 1) throw new Exception("Book is not deleted. Some internal error on DBMS side");

                response.Message = "PreDelete done";
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


        public Response GetAllBooks()
        {
            Response response = new Response();
            try
            {
                List<FDAP03> lst = _dbConnection.Select<FDAP03>(x => x.A03F04 == _fdap01.A01F01);

                response.Data = lst;
                response.Message = "PreDelete done";
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
