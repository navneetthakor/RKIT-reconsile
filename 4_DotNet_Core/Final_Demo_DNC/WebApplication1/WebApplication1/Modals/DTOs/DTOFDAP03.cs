using WebApplication1.Modals.POCOs;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;


namespace WebApplication1.Modals.DTOs
{
    public class DTOFDAP03
    {

        [JsonProperty("A03302")]
        public string A03F02 { get; set; } // title

        [JsonProperty("A03303")]
        public string A03F03 { get; set; } // description
    }

  
}
