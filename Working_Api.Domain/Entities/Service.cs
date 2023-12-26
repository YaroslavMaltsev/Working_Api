using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string NameService { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte[] image { get; set; }
    }
}
