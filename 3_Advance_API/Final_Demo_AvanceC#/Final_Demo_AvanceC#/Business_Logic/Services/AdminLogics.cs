using System;
using System.Data;
using Final_Demo_AvanceCSharp.Business_Logic.Interfaces;
using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using ServiceStack;
using ServiceStack.OrmLite;

namespace Final_Demo_AvanceCSharp.Business_Logic
{
    internal class AdminLogics : IDbDeleteOppar
    {
        private IDbConnection _dbConnection;
        private FDAP01 _fdap01;
        private FDAP03 _fdap03;

        public AdminLogics(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
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
                if(typeOfDelete == WOBEnum.Author)
                {
                    _fdap01 = new FDAP01() { A01F01 = id };
                }
                else
                {
                    _fdap03 = new FDAP03() { A03F01 = id };
                }

                response.Message = "PreDelete Completed";
                return response;
            }catch(Exception ex)
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
                response.Data = l1.Join(l2, l1 => l1.A01F01, l2 => l2.A03F04, (a, b) => new { a = a, b = b })
                    .ToList();

                // Define the column headers
                string[] headers = { "Author_id", "Author_name", "Book_id", "Bookd_title", "Book_desc" };

                // Calculate the maximum width for each column
                int[] columnWidths = {15,15, 15, 20, 20, 50 };

                // Print the header row
                PrintRow(headers, columnWidths);
                Console.WriteLine(new string('-', columnWidths.Sum() + (headers.Length - 1) * 3)); // separator line

                foreach (dynamic x in (IEnumerable<Object>)response.Data)
                {
                    string[] rowValues = {
                            $"{x.a.A01F01}",
                            x.a.A01F02,
                            $"{ x.b.A03F01 }",
                            x.b.A03F02,
                            x.b.A03F03
                        };

                    PrintRow(rowValues, columnWidths);
                }

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
                response.Data = l1.Join(l2, l1 => l1.A01F01, l2 => l2.A02F01, (a, b) => new { a = a, b = b })
                    .Where(x => x.b.A02F02 == A02F01Values.Author)
                    .ToList();

                // Define the column headers
                string[] headers = { "Author_id", "Author_name", "Author_email", "Author_phone" };

                // Calculate the maximum width for each column
                int[] columnWidths = { 15, 15, 15, 15 };

                // Print the header row
                PrintRow(headers, columnWidths);
                Console.WriteLine(new string('-', columnWidths.Sum() + (headers.Length - 1) * 3)); // separator line
                foreach (dynamic x in (IEnumerable<Object>)response.Data)
                {
                    string[] rowValues = {
                            $"{x.a.A01F01}",
                            x.a.A01F02,
                            x.a.A01F03,
                            x.a.A01F05
                        };

                    PrintRow(rowValues, columnWidths);
                }

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

        // Helper method to print a single row
        public static void PrintRow(string[] rowValues, int[] columnWidths)
        {
            for (int i = 0; i < rowValues.Length; i++)
            {
                Console.Write(rowValues[i].PadRight(columnWidths[i]) + " | ");
            }
            Console.WriteLine();
        }


    }
}
