using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Working_Api.Domain.DTOs
{
    public class WorkerDTO
    {
        [Required]
        public string NameWorker { get; set; }
        public string Surname { get; set; }
        public int PostId { get; set; }
        public IFormFile Image { get; set; }
    }
}
