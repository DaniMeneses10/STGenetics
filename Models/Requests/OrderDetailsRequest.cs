using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Models.Requests
{
    public class OrderDetailsRequest
    {        
        public Guid OrderId { get; set; }
        public List<AnimalDetailsRequest> AnimalsList { get; set; }           
    }
}
