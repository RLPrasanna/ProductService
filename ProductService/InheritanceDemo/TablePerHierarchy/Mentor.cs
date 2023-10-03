using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerHierarchy
{
    public class Mentor:User
    {
        public double averageRating { get; set; }
    }
}
