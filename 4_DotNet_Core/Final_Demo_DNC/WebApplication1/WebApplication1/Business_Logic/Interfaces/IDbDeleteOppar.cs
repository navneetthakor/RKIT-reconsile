using WebApplication1.Modals.Enums;
using WebApplication1.Utilitlies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Business_Logic.Interfaces
{
    internal interface IDbDeleteOppar
    {
        /// <summary>
        /// It converts DTO to POCO
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response PreDelete(int id);

        /// <summary>
        /// to validate provided values
        /// </summary>
        /// <returns>Response : to indicate success or failuer of a given action</returns>
        Response ValidateOnDelete();

        /// <summary>
        /// to save data in database
        /// </summary>
        /// <returns>Response : to indiacate success or failuer of a given action</returns>
        Response Delete();
    }
}
