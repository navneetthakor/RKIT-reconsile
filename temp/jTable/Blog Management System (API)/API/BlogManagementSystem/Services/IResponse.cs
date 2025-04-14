using System.Data;

namespace BlogManagementSystem.Services
{

    /// <summary>
    /// Interface of Respose Model.
    /// </summary>
    public interface IResponse
    {

        /// <summary>
        /// Check error occuring or not.
        /// </summary>
        public bool IsError { get; set; }


        /// <summary>
        /// Message according to the success or error Response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Store data of Response.
        /// </summary>
        public DataTable Data { get; set; }

    }
}
