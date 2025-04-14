using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogManagementSystem.Models.DTO
{
    /// <summary>
    /// DTO model of Blog Table
    /// </summary>
    public class DTOBLG01
    {
        /// <summary>
        /// ID (Primary Key).
        /// </summary>
        [Required(ErrorMessage = "ID is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "ID must be positive.")]    
        [JsonProperty("G01101")]
        [JsonPropertyName("G01101")]
        public int G01F01 { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        /// 
        
        [Required(ErrorMessage = "Title is Required.")]
        [JsonProperty("G01102")]
        [JsonPropertyName("G01102")]
        public string G01F02 { get; set; } = string.Empty;

        /// <summary>
        /// Content.
        /// </summary>
        [Required(ErrorMessage = "Content is Required.")]
        [JsonProperty("G01103")]
        [JsonPropertyName("G01103")]

        public string G01F03 { get; set; } = string.Empty;

    }
}
