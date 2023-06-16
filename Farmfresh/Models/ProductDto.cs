using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farmfresh.Models
{
    [DataContract(Name = "product")]
    public class ProductDto
    {
        [Required]
        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [Required]
        [DataMember(Name = "photo")]
        public IFormFile Photo { get; set; }
    }
}
