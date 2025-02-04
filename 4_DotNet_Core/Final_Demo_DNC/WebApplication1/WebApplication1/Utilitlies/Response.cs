using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Utilitlies
{
    public class Response
    {
        /// <summary>
        /// if request issucessful and we have data to send
        /// </summary>
        public dynamic Data { get; set; } = new { };

        /// <summary>
        /// if error then False otherwise true
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Message which indicates outcome of this request
        /// </summary>
        public string Message { get; set; } = "";

        public MyStatusCodes StatusCode { get; set; }
    }

    public enum MyStatusCodes
    {
        Internal_server_Error = 500,
        Unauthorized=400,
        Success=200,
    }
}
