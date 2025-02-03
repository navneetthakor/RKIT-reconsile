using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Demo_AvanceCSharp.Modals.DTOs
{
    public class DTOFDAP01
    {

        [JsonProperty("A01102")]
        public string A01F02 { get; set; } // name

        [JsonProperty("A01103")]
        public string A01F03 { get; set; } // email

        [JsonProperty("A01104")]
        public string A01F04 { get; set; } // password

        [JsonProperty("A01105")]
        public string A01F05 { get; set; } // phone
    }
}
