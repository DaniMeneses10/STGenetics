using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Interfaces
{
    public interface IOrderAnimalService
    {
        public bool CreateAnimalOrderDetails(OrderDetailsRequest request);
        double CalculateTotalWithDiscount(double animalPrice, double animalsAmount);
    }
}
