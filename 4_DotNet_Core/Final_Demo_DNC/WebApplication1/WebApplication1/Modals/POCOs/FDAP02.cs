using ServiceStack.DataAnnotations;
using System;

namespace WebApplication1.Modals.POCOs
{
    public enum A02F01Values
    {
        Admin,
        Author
    }
    public class FDAP02
    {
        [PrimaryKey ,ForeignKey(type: typeof(FDAP01), OnDelete = "CASCADE")]
        public int A02F01 { get; set; } // id of user

        public A02F01Values A02F02 { get; set;} // role of user
    }
}
