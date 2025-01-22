using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Utilitlies;
using System;


namespace Final_Demo_AvanceCSharp.Business_Logic.Interfaces
{
    internal interface IDbDeleteAdmin
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
