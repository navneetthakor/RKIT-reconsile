using ServiceStack.DataAnnotations;
using System;

namespace Final_Demo_AvanceCSharp.Modals.POCOs
{
    public enum A02F01Values
    {
        Admin,
        Auther
    }
    public class FDAP02
    {
        [PrimaryKey ,ForeignKey(type: typeof(FDAP01), OnDelete = "CASCADE")]
        public string A02F01 { get; set; } // id of user

        public A02F01Values A02F02 { get; set;} // role of user
    }
}
