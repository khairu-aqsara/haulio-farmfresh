using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farmfresh.Models
{
    [DataContract(Name = "categories")]
    public class CategoryDto
    {
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
