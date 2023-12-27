using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Working_Api.Domain.Entities;

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
