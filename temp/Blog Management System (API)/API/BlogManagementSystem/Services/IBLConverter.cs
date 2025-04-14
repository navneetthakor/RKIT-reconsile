using System.Data;

namespace BlogManagementSystem.Services
{
    /// <summary>
    /// Interface for converting objects to DataTables.
    /// </summary>
    public interface IBLConverter
    {
        /// <summary>
        /// Converts a single object to a DataTable.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A DataTable representation of the object.</returns>
        public DataTable ObjectToDataTable<T>(T obj) where T : class;

        /// <summary>
        /// Converts a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T">Type of the objects.</typeparam>
        /// <param name="obj">The list of objects to convert.</param>
        /// <returns>A DataTable representation of the list.</returns>
        public DataTable ToDataTable<T>(List<T> obj) where T : class;
    }
}
