using Newtonsoft.Json;
using System;


namespace WebApplication1.Modals.DTOs
{
    public class DTOFDAP11
    {
        [JsonProperty("A01101")]
        public int A01F01 { get; set; }

        [JsonProperty("A01102")]
        public string A01F02 { get; set; } // name

        [JsonProperty("A01103")]
        public string A01F03 { get; set; } // email

        [JsonProperty("A01105")]
        public string A01F05 { get; set; } // phone
    }
}
