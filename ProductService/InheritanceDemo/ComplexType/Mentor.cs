using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.ComplexType
{
    [Table("c_mentor")]
    public class Mentor
    {
        [Key] // Define the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public double averageRating { get; set; }
        public User user { get; set; }
    }
}
