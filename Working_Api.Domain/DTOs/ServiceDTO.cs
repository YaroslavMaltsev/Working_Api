using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.DTOs
{
    public class ServiceDTO
    {
        [Required]
        public string NameService { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile image { get; set; }
    }
}
