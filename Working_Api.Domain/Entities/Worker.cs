using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Working_Api.Domain.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        public string NameWorker { get; set; }
        public string Surname { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; }
        public byte[] Image { get; set; }
    }
}
