using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STGeneticsProject.Models.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public double Total { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
