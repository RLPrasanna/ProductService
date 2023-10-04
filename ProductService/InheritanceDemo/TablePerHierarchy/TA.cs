using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerHierarchy
{
    public class TA:User
    {
        public double averageRating { get; set; }
    }
}
