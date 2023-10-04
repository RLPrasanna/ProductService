using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerType
{
    [Table("tpt_ta")]
    public class TA:User
    {
        public double averageRating { get; set; }
    }
}
