using ServiceStack.DataAnnotations;
using System;

namespace Final_Demo_AvanceCSharp.Modals.POCOs
{
    public enum A02F01Values
    {
        Admin,
        Author
    }
    public class FDAP02
    {
        [PrimaryKey ,ForeignKey(type: typeof(FDAP01), OnDelete = "CASCADE")]
        ///<summary>
        ///Id_of_user
        /// </summary>
        public int A02F01 { get; set; }

        ///<summary>
        ///role of User
        /// </summary>
        public A02F01Values A02F02 { get; set;}
    }
}
