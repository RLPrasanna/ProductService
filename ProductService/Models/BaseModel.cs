using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Models
{
    public class BaseModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
