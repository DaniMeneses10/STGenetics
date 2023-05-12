namespace STGeneticsProject.Models.Responses
{
    public class OrderDetailsResponse
    {
        public Guid OrderDetailsId { get; set; }
        public Guid AnimalId { get; set; }
        public double PricePerUnit { get; set; }
        public int AnimalsAmount { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
    }
}
