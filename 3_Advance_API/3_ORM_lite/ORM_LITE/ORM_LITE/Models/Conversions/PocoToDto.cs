using ORM_LITE.Models.DTOs;
using ORM_LITE.Models.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal static class PocoToDto
    {
        internal static DTOAEWP01 ToDTO(this POCOAEWP01 pocoaewp01)
        {
            return new DTOAEWP01()
            {
                P01102 = pocoaewp01.P01F02,
                P01103 = pocoaewp01.P01F03,
                P01104 = pocoaewp01.P01F04,
                P01105 = pocoaewp01.P01F05
            };
        }

        internal static DTOAEWP02 ToDTO(this POCOAEWP02 pocoaewp02)
        {
            return new DTOAEWP02()
            {
                P02202 = pocoaewp02.P02F02,
                P02203 = pocoaewp02.P02F03
            };
        }

        internal static DTOAEWP03 ToDTO(this POCOAEWP01 pocoaewp01, POCOAEWP02 pocoaewp02)
        {
            return new DTOAEWP03()
            {
                P02201 = pocoaewp02.P02F01,
                P02202 = pocoaewp02.P02F02,
                P01102 = pocoaewp01.P01F02
            };
        }

        internal static DTOAEWP03 ToDTO(this POCOAEWP02 pocoaewp02, POCOAEWP01 pocoaewp01)
        {
            return new DTOAEWP03()
            {
                P02201 = pocoaewp02.P02F01,
                P02202 = pocoaewp02.P02F02,
                P01102 = pocoaewp01.P01F02
            };
        }
    }
}
