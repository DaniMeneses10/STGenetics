using System.ComponentModel.DataAnnotations.Schema;

namespace STGeneticsProject.Models.Entities
{
    [Table("Animals")]
    public class Animal
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
