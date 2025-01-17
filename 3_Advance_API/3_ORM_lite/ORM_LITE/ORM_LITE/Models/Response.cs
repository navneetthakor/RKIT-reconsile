using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Models
{
    public class Response
    {
        /// <summary>
        /// if request issucessful and we have data to send
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// if error then False otherwise true
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Message which indicates outcome of this request
        /// </summary>
        public string Message { get; set; } = "";


    }
}
