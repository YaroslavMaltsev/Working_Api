
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.DTOs
{
    public class ProjectDTO
    {
        [Required]
        public string NameProject { get; set; }
        public string Description { get; set; }
        [Required]
        public string Link { get; set; }
        public IFormFile Image { get; set; }
    }
}
