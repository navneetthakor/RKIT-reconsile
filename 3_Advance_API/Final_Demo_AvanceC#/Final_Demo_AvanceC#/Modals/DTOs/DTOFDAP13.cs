using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceC_.Modals.DTOs
{
    public class DTOFDAP13
    {
        [JsonProperty("A03301")]
        public int A03F01 { get; set; }  // id

        [JsonProperty("A03302")]
        public string A03F02 { get; set; } // title

        [JsonProperty("A03303")]
        public string A03F03 { get; set; } // description
    }
}
