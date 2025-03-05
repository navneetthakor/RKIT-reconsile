using ServiceStack.DataAnnotations;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Final_Demo_AvanceCSharp.Modals.POCOs
{
    /// <summary>
    /// POCO class for : User
    /// </summary>
    public class FDAP01
    {
        [PrimaryKey, AutoIncrement]
        ///<summary>
        ///Id
        /// </summary>
        public int A01F01 { get; set; }

        ///<summary>
        ///Name
        /// </summary>
        public string A01F02 { get; set; }

        [Unique, NotNull]
        ///<summary>
        ///Email
        /// </summary>
        public string A01F03 { get; set; }

        ///<summary>
        ///Password
        /// </summary>
        public string A01F04 { get; set; } 

        [StringLength(10)]
        ///<summary>
        ///Phone
        /// </summary>
        public string A01F05 { get; set; }

    }
}
 