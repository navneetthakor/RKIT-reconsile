using Final_Demo_AvanceCSharp.Business_Logic.Interfaces;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using System.Data;
using System;
using Final_Demo_AvanceCSharp.Modals.DTOs;
using Final_Demo_AvanceCSharp.Modals.Enums;
using ServiceStack.OrmLite;

namespace Final_Demo_AvanceCSharp.Business_Logic
{
    internal class AuthorLogics : IDbAddOppar
    {
        private IDbConnection _dbConnection;
        private FDAP03 _fdap03;
        private FDAP01 _fdap01;
        public AuthorLogics(IDbConnection dbConnection, FDAP01 fdap01)
        {
            _dbConnection = dbConnection;
            _fdap01 = fdap01;
        }

        /// <summary>
        /// Presave for : adding or updating entry in the database
        /// </summary>
        /// <param name="dtofdap03">input dto that we are getting</param>
        /// <returns>Response object</returns>
        public Response PreSave(DTOFDAP03 dtofdap03)
        {
            Response response = new Response();
            try
            {
                _fdap03 = new FDAP03();
                _fdap03.A03F02 = dtofdap03.A03F02; // title of book
                _fdap03.A03F03 = dtofdap03.A03F03; // desc of book
                _fdap03.A03F04 = _fdap01.A01F01; // id of author
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
                    List<FDAP03> lst = _dbConnection.Select<FDAP03>(x => x.A03F02 == _fdap03.A03F02 && x.A03F04 == _fdap01.A01F01);
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

        public Response Save(OppEnum AOU)
        {
            Response response = new Response();
            try
            {
                if (AOU == OppEnum.A)
                {
                    var result = _dbConnection.Insert<FDAP03>(_fdap03);
                    if (result != 1) throw new Exception("Book with same title exists for current Author");
                }
                else
                {
                    // checking with id becasue use can't update id
                    List<FDAP03> lst = _dbConnection.Select<FDAP03>($"select * from fdap03 where A03F01 = {_fdap03.A03F01} and A03F04 = {_fdap01.A01F03}");
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
    }
}
