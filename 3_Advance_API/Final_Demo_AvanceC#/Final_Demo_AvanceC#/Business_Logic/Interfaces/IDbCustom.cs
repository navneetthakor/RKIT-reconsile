using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Demo_AvanceCSharp.Utilities;

namespace Final_Demo_AvanceCSharp.Business_Logic.Interfaces
{
    /// <summary>
    /// This interface defines essential methods that all the classes 
    /// which are related to business logic must implement it.
    /// </summary>
    internal interface IDbCustom
    {
        /// <summary>
        /// It converts DTO to POCO
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response PreSave();

        /// <summary>
        /// to validate provided values
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response ValidateOnSave();

        /// <summary>
        /// to save data in database
        /// </summary>
        /// <returns>Response : to indiacate success or failuer of a given action</returns>
        Response Save();
    }
}
