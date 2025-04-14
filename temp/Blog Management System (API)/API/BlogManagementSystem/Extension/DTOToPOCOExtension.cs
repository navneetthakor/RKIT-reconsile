using System.Reflection;

namespace BlogManagementSystem.Extension
{
    /// <summary>
    /// Extension methods to convert DTO (Data Transfer Object) to POCO (Plain Old CLR Object).
    /// </summary>
    public static class DTOToPOCOExtension
    {
        /// <summary>
        /// Converts a DTO object to its corresponding POCO type.
        /// </summary>
        /// <typeparam name="POCO">The target POCO type that the DTO will be converted to.</typeparam>
        /// <param name="objDTO">The DTO object to be converted.</param>
        /// <returns>A POCO instance with the same property values as the DTO.</returns>
        public static POCO Convert<POCO>(this object objDTO)
        {
            // Get the type of the POCO
            Type pocoType = typeof(POCO);

            // Create a new instance of the POCO type
            POCO pocoInstance = (POCO)Activator.CreateInstance(pocoType);

            // Get the properties of the DTO object
            PropertyInfo[] dtoProperties = objDTO.GetType().GetProperties();

            // Get the properties of the POCO type
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            // Iterate through each property in the DTO
            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                // Find the corresponding property in the POCO with the same name
                PropertyInfo pocoProperty = Array.Find(pocoProperties, p => p.Name == dtoProperty.Name);

                // If the matching property is found and their types are compatible, copy the value
                if (pocoProperty != null && dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    // Get the value from the DTO property
                    object value = dtoProperty.GetValue(objDTO);

                    // Set the value in the POCO property
                    pocoProperty.SetValue(pocoInstance, value);
                }
            }

            // Return the populated POCO instance
            return pocoInstance;
        }
    }
}
