using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Business_Logic.Interfaces
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
        /// <param name="ErrorMessage"></param>
        /// <returns>bool : to indicate success or failuer of a given action</returns>
        bool PreSave(out string ErrorMessage);

        /// <summary>
        /// to validate provided values
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>bool : to indicate success or failuer of a given action</returns>
        bool validate(out string ErrorMessage);

        /// <summary>
        /// to save data in database
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>bool : to indiacate success or failuer of a given action</returns>
        bool save(out string ErrorMessage);
    }
}
