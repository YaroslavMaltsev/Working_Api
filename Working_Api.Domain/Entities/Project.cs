

using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string NameProject { get; set; }
        public string Description { get; set; }
        [Required]
        public string Link { get; set; }
        public byte[] Image { get; set; }
    }
}
