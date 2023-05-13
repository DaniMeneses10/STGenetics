using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;
using STGeneticsProject.Models.Responses;

namespace STGeneticsProject.Interfaces
{
    public interface IOrderService
    {
        Order CreateNewOrder(Order request);
        ItemDetails AddNewItem(OrderDetailsRequest request);
        double CalculateTotalWithDiscount(double animalPrice, double animalsAmount);
        Order GetOrderInformation(Guid orderId);
    }
}
