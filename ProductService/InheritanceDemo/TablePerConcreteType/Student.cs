using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerConcreteType
{
    [Table("tpc_student")]
    public class Student:User
    {
        public double psp { get; set; }
        public double attendance { get; set; }
    }
}
