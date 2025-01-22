using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Utilitlies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceCSharp.Business_Logic.Interfaces
{
    internal interface IDbDeleteOppar
    {
        /// <summary>
        /// It converts DTO to POCO
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response PreDelete(int id, WOBEnum typeOfDelete);

        /// <summary>
        /// to validate provided values
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response ValidateOnDelete(WOBEnum typeOfDelete);

        /// <summary>
        /// to save data in database
        /// </summary>
        /// <returns>Response : to indiacate success or failuer of a given action</returns>
        Response Delete(WOBEnum typeOfDelete);
    }
}
