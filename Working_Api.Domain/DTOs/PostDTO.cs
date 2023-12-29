using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.DTOs
{
    public class PostDTO
    {
        [Required]
        public string NamePost { get; set; }
        public string Description { get; set; }
    }
}
