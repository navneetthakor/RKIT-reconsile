using ServiceStack.DataAnnotations;
using System;


namespace Final_Demo_AvanceCSharp.Modals.POCOs
{
    /// <summary>
    /// Book : poco class
    /// </summary>
    public class FDAP03
    {
        [Index, PrimaryKey, AutoIncrement]
        ///<summary>
        ///Id
        /// </summary>
        public int A03F01 { get; set; }

        ///<summary>
        ///Title
        /// </summary>
        public string A03F02 { get; set; }

        ///<summary>
        ///Description
        /// </summary>
        public string A03F03 { get; set; }

        [ForeignKey(type: typeof(FDAP01), OnDelete = "CASCADE")]
        ///<summary>
        ///Id_of_Author
        /// </summary>
        public int A03F04 { get; set; }
    }
}
