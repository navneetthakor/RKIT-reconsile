using BlogManagementSystem.Models.DTO;
using BlogManagementSystem.Models;
using BlogManagementSystem.Services;
using BlogManagementSystem.Models.Enum;

namespace BlogManagementSystem.BL
{
    /// <summary>
    /// Interface for blog business logic operations.
    /// </summary>
    public interface IBLBLog
    {

        /// <summary>
        /// Type of Operation (Add,Edit,Delete)
        /// </summary>
        public EnmType Type { get; set; }


        /// <summary>
        /// Retrieves all blog records.
        /// </summary>
        /// <returns>Response object containing blog data or error message.</returns>
        IResponse GetAllBlogs(int pageSize, int pageNumber, string sorting);

        /// <summary>
        /// Retrieves a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object containing blog data or error message.</returns>
        IResponse GetBlogByID(int id);

        /// <summary>
        /// Prepares the blog entity for saving (add/edit).
        /// </summary>
        /// <param name="objDTOBLG01">DTO object for blog.</param>
        void PreSave(DTOBLG01 objDTOBLG01);

        /// <summary>
        /// Validates the save operation for add/edit.
        /// </summary>
        /// <returns>Response object indicating validation result.</returns>
        IResponse ValidationSave();

        /// <summary>
        /// Saves the blog record (add/edit).
        /// </summary>
        /// <returns>Response object indicating save result.</returns>
        IResponse Save();

        /// <summary>
        /// Deletes a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object indicating deletion result.</returns>
        IResponse Delete(int id);
    }
}
