using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Models.POCOs
{
    internal class POCOAEWP01
    {
        [PrimaryKey, Index, AutoIncrement]
        public int P01F01 { get; set; } // writerId

        [StringLength(50)]
        public string P01F02 { get; set; } // name

        [StringLength(16)]
        public string P01F03 { get; set; } //password

        [Unique, NotNull, Index]
        public string P01F04 { get; set; } // Email

        [StringLength(10)]
        public string P01F05 { get; set; } // password
    }
}
