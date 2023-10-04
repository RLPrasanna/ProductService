using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerConcreteType
{
    [Table("tpc_mentor")]
    public class Mentor:User
    {
        public double averageRating { get; set; }
    }
}
