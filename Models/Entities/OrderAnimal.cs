using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STGeneticsProject.Models.Entities
{
    [Table("OrdersAnimals")]
    public class OrderAnimal
    {
        [Key]
        public Guid OrderAnimalId { get; set; }
        public Guid OrderId { get; set; }
        public Guid AnimalId { get; set; }
        public double PricePerUnit { get; set; }
        public int AnimalsAmount { get; set; }
        public double TotalPerItem { get; set; }        
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
