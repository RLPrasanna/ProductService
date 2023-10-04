using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerHierarchy
{
    public class Student:User
    {
        public double psp { get; set; }
        public double attendance { get; set; }
    }
}
