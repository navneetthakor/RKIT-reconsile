using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Modals.POCOs
{
    /// <summary>
    /// POCO class for : User
    /// </summary>
    public class FDAP01
    {
        [JsonProperty("A01101")]
        [PrimaryKey, AutoIncrement]
        public int A01F01 { get; set; } // id

        [JsonProperty("A01102")]
        public string A01F02 { get; set; } // name

        [JsonProperty("A01103")]
        [Unique, NotNull]
        public string A01F03 { get; set; } // email

        [JsonProperty("A01104")]
        public string A01F04 { get; set; } // password

        [JsonProperty("A01105")]
        [StringLength(10)]
        public string A01F05 { get; set; } // phone

    }
}
 