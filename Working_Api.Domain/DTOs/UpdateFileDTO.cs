using Microsoft.AspNetCore.Http;

namespace Working_Api.Domain.DTOs
{
    public class UpdateFileDTO
    {
        public IFormFile image {  get; set; }
    }
}
