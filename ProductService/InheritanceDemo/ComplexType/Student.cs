using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.ComplexType
{
    [Table("c_student")]
    public class Student
    {
        [Key] // Define the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public double psp { get; set; }
        public double attendance { get; set; }
        public User user { get; set; }
    }
}
