using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerConcreteType
{
    [Table("tpc_ta")]
    public class TA:User
    {
        public double averageRating { get; set; }
    }
}
