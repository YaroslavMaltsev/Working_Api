using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string NamePost { get; set; }
        public string Description { get; set; }
    }
}
