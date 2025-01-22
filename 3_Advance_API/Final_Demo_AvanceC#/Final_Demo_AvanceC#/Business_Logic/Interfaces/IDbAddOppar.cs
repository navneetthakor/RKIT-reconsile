using System;
using Final_Demo_AvanceCSharp.Modals.DTOs;
using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;

namespace Final_Demo_AvanceCSharp.Business_Logic.Interfaces
{
    /// <summary>
    /// This interface defines essential methods that all the classes 
    /// which are related to business logic must implement it.
    /// </summary>
    internal interface IDbAddOppar
    {
        /// <summary>
        /// It converts DTO to POCO
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response PreSave(DTOFDAP03 _dtofdap03);

        /// <summary>
        /// to validate provided values
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response ValidateOnSave(OppEnum AOU);

        /// <summary>
        /// to save data in database
        /// </summary>
        /// <returns>Response : to indiacate success or failuer of a given action</returns>
        Response Save(OppEnum AOU);

        
    }
}
