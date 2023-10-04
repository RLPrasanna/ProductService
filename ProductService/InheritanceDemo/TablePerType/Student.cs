using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerType
{
    [Table("tpt_student")]
    public class Student:User
    {
        public double psp { get; set; }
        public double attendance { get; set; }
    }
}
