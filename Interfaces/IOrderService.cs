using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Interfaces
{
    public interface IOrderService
    {
        Order CreateNewOrder(NewOrderRequest request);
        void CreateAnimalOrderDetails(Guid orderId, List<AnimalDetailsRequest> animals);
        Order GetOrderInformation(Guid orderId);
    }
}
