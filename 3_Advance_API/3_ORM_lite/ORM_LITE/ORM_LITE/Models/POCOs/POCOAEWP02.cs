using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Models.POCOs
{
    internal class POCOAEWP02
    {
        [PrimaryKey, Index, AutoIncrement]
        public int P02F01 { get; set; } // bookid

        [Index, Unique, NotNull]
        public string P02F02 { get; set; } // name

        [ForeignKey(type: typeof(POCOAEWP01))]
        public int P02F03 { get; set; } // writer id

    }
}
