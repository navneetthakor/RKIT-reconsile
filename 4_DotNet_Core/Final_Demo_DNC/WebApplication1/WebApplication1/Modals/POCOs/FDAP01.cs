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
        [PrimaryKey, AutoIncrement]
        public int A01F01 { get; set; } // id

        public string A01F02 { get; set; } // name

        [Unique, NotNull]
        public string A01F03 { get; set; } // email

        public string A01F04 { get; set; } // password

        [StringLength(10)]
        public string A01F05 { get; set; } // phone

    }
}
 