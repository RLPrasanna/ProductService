using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.InheritanceDemo.TablePerType
{
    [Table("tpt_mentor")]
    public class Mentor:User
    {
        public double averageRating { get; set; }
    }
}
