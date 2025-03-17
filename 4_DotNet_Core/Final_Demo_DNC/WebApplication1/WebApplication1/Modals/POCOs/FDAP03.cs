using ServiceStack.DataAnnotations;
using System;


namespace WebApplication1.Modals.POCOs
{
    /// <summary>
    /// Book : poco class
    /// </summary>
    public class FDAP03
    {
        [Index, PrimaryKey, AutoIncrement]
        ///<summary>
        ///id
        ///</summary>
        public int A03F01 { get; set; }  // id

        ///<summary>
        ///book title
        ///</summary>
        public string A03F02 { get; set; } // title

        ///<summary>
        ///description
        ///</summary>
        public string A03F03 { get; set; } // description

        [ForeignKey(type: typeof(FDAP01), OnDelete = "CASCADE")]
        ///<summary>
        ///author id
        ///</summary>
        public int A03F04 { get; set; } // author id
    }
}
