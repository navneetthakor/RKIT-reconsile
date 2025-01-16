using ORM_LITE.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_LITE.Models.POCOs;


namespace System
{
    internal static class DtoToPoco
    {
        internal static POCOAEWP01 ToPOCO(this DTOAEWP01 dtoaewp01)
        {
            return new POCOAEWP01()
            {
                P01F02 = dtoaewp01.P01102,
                P01F03 = dtoaewp01.P01103,
                P01F04 = dtoaewp01.P01104,
                P01F05 = dtoaewp01.P01105,
            };
        }

        internal static POCOAEWP02 ToPOCO(this DTOAEWP02 dtoaewp02)
        {
            return new POCOAEWP02()
            {
                P02F02 = dtoaewp02.P02202,
                P02F03 = dtoaewp02.P02203,
            };

        }
    }
}







