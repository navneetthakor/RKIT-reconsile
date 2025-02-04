using System;
using WebApplication1.Modals.DTOs;
using WebApplication1.Modals.Enums;
using WebApplication1.Modals.POCOs;
using WebApplication1.Utilitlies;

namespace WebApplication1.Business_Logic.Interfaces
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
        Response PreSave(FDAP03 fdap03, OppEnum AOU);

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
