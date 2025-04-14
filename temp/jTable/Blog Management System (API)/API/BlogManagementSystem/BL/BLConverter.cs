using BlogManagementSystem.Services;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace BlogManagementSystem.BL
{
    /// <summary>
    /// Provides methods to convert objects and collections to DataTable.
    /// </summary>
    public class BLConverter : IBLConverter
    {
        /// <summary>
        /// Converts a list of objects into a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="obj">The list of objects to be converted.</param>
        /// <returns>A DataTable representation of the list.</returns>
        public DataTable ToDataTable<T>(List<T> obj) where T : class
        {
            // Serialize the list to JSON and deserialize it into a DataTable.
            string json = JsonConvert.SerializeObject(obj);
            DataTable objDataTable = JsonConvert.DeserializeObject<DataTable>(json);

            return objDataTable;
        }

        /// <summary>
        /// Converts a single object to a DataTable with one row.
        /// </summary>
        /// <typeparam name="T">The type of the object to be converted.</typeparam>
        /// <param name="obj">The object to be converted.</param>
        /// <returns>A DataTable containing the object's properties as columns.</returns>
        public DataTable ObjectToDataTable<T>(T obj) where T : class
        {
            DataTable dataTable = new DataTable();

            // Return an empty DataTable if the input object is null.
            if (obj == null)
                return dataTable;

            Type objectType = typeof(T);
            PropertyInfo[] properties = objectType.GetProperties();

            // Add columns to the DataTable based on the object's properties.
            foreach (PropertyInfo property in properties)
            {
                // Add column with property name and type, handling nullable types.
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Create a DataRow and populate it with the object's property values.
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo property in properties)
            {
                // Assign property value or DBNull if null.
                row[property.Name] = property.GetValue(obj) ?? DBNull.Value;
            }

            // Add the row to the DataTable.
            dataTable.Rows.Add(row);

            return dataTable;
        }
    }
}
