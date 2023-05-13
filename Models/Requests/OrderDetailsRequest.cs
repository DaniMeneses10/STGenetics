namespace STGeneticsProject.Models.Requests
{
    public class OrderDetailsRequest
    {        
        public Guid OrderId { get; set; }
        public Guid AnimalId { get; set; }
        public int AnimalsAmount { get; set; }                
    }
}
