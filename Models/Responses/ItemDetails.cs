using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STGeneticsProject.Models.Responses
{
    [Table("ItemsDetails")]
    public class ItemDetails
    {
        [Key]
        public Guid OrderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public Guid AnimalId { get; set; }
        public double PricePerUnit { get; set; }
        public int AnimalsAmount { get; set; }        
        public double TotalPerItem { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

    }
}
