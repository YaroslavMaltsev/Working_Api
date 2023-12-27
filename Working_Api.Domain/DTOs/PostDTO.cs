using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_Api.Domain.DTOs
{
    public class PostDTO
    {
        [Required]
        public string NamePost { get; set; }
        public string Description { get; set; }
    }
}
