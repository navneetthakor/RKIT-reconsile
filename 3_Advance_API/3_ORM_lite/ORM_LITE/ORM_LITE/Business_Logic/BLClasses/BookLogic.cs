using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_LITE.Business_Logic.Interfaces;
using ORM_LITE.Models;
using ORM_LITE.Models.DTOs;
using ORM_LITE.Models.Enum;
using ORM_LITE.Models.POCOs;
using ServiceStack;
using ServiceStack.OrmLite;

namespace ORM_LITE.Business_Logic.BLClasses
{
    public class BookLogic : IDbCustom
    {
        /// <summary>
        /// if we want to save data then '_pocoObj' will work like intermediate object
        /// </summary>
        private POCOAEWP02? _pocoObj;
        private DTOAEWP02? _dtoObj;
        private OperationType _type;
        private IDbConnection _dbConnection;

        /// <summary>
        /// to add object reference in DTOAEWP02
        /// </summary>
        /// <param name="dtoObj"></param>
        public BookLogic(DTOAEWP02? dtoObj, OperationType type, IDbConnection dbConnection)
        {
            _pocoObj = null;
            _dtoObj = dtoObj;
            _type = type;
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Default construtor : in case of we just want to read a data.
        /// </summary>
        public BookLogic(OperationType type, IDbConnection dbConnection)
        {
            _pocoObj = null;
            _dtoObj = null;
            _type = type;
            _dbConnection = dbConnection;
        }


        /// <summary>
        /// - this method is defined in 'IDbCustom' interface
        /// - Converts DTO to POCO
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>Response : to indicate success or failuer of this method task</returns>
        public Response PreSave()
        {
            Response response = new Response();
            try
            {

                // check whether DTOAEWP02 object is provided or not.
                if (_dtoObj == null) throw new Exception("DTO object is null");

                // converting to Poco
                this._pocoObj = _dtoObj.ToPOCO();

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }


        public Response Validate()
        {
            Response response = new Response();
            try
            {
                // check is this operation other than 'Add' || P01F01 is not empty
                if (_pocoObj.P02F01 == 0 && _type != OperationType.A)
                {
                    throw new Exception("You must pass WriterId");
                }

                //check all the constraints regarding POCO 
                if (_pocoObj.P02F02 == null || _pocoObj.P02F03 == null)
                {
                    throw new Exception("You must pass WriterId");
                }

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }

        public Response Save()
        {
            Response response = new Response();
            try
            {
                switch (_type)
                {
                    case OperationType.A:
                        _dbConnection.Insert<POCOAEWP02>(_pocoObj);
                        response.Data = _pocoObj;
                        return response;

                    case OperationType.E:
                        _dbConnection.Update<POCOAEWP02>(_pocoObj);
                        response.Data = _pocoObj;
                        return response;

                    default:
                        throw new Exception("Non proper operation type");
                };
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }


        public Response GetBook(int id)
        {
            Response response = new Response();
            try
            {

                response.Data = _dbConnection.SingleById<POCOAEWP02>(id).ToDTO();
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }

        public Response GetAllBookByWriter(int writerId)
        {
            Response response = new Response();
            try
            {

                List<POCOAEWP02> fetchedBooks = _dbConnection.Select<POCOAEWP02>(b => b.P02F03 == writerId).ToList();
                response.Data = fetchedBooks.Map(b => b.ToDTO());
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }

        public Response DeleteBook(int id)
        {
            Response response = new Response();
            try
            {

                DTOAEWP02 selectedPocoaewp02 = _dbConnection.SingleById<POCOAEWP02>(id).ToDTO();
                response.Data = selectedPocoaewp02;
                _dbConnection.Delete(selectedPocoaewp02);
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsError = true;
                return response;
            }
        }
}
}
