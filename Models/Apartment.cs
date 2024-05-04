
using System.ComponentModel.DataAnnotations;

namespace Restify.Models
{
    public class Apartment
    {
         [Key]
         public int? apartment_id { get; set; }
        [Required]
         public string? apartment_name { get; set; }
         public string? apartment_details { get; set; }
        public string? apartment_location { get; set; }
        public byte[]? apartment_image { get; set; }
         
          
    }
}
