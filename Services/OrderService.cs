using Azure.Core;
using STGeneticsProject.Database;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;
using STGeneticsProject.Models.Responses;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace STGeneticsProject.Services
{
    public class OrderService : IOrderService
    {
        STGeneticsDBContext _context;
        IValidatorOrderAnimals _validatorOrderAnimals;
        IOrderAnimalService _orderAnimalService;

        public OrderService(STGeneticsDBContext context, 
                            IValidatorOrderAnimals validatorOrderAnimals,
                            IOrderAnimalService orderAnimalService)
        {
            this._context = context;
            this._validatorOrderAnimals = validatorOrderAnimals;
            this._orderAnimalService = orderAnimalService;
        }
        public Order CreateNewOrder(NewOrderRequest request)
        {
            var newOrder = new Order();
            newOrder.OrderId = Guid.NewGuid();
            newOrder.CreateDate = DateTime.UtcNow;

            var animals = request.AnimalsList;
            newOrder.Error = _validatorOrderAnimals.ValidateOrderAnimalList(animals);

            CreateAnimalOrderDetails(newOrder.OrderId, animals);

            var totalOrder = CalculateTotalOrder(newOrder.OrderId);

            newOrder.TotalPrice = totalOrder.TotalPrice;
            newOrder.TotalAnimals = totalOrder.TotalAnimals;

            this._context.Orders.Add(newOrder);
            this._context.SaveChanges();

            return newOrder;
        }
        
        public void CreateAnimalOrderDetails(Guid orderId, List<AnimalDetailsRequest> animals)
        {
            var orderDetailsRequest = new OrderDetailsRequest();
            orderDetailsRequest.OrderId = orderId;
            orderDetailsRequest.AnimalsList = animals;
            this._orderAnimalService.CreateAnimalOrderDetails(orderDetailsRequest);
        }

        public TotalOrderResponse CalculateTotalOrder(Guid orderId)
        {
            var orderAnimals = this._context.OrdersAnimals.Where(x => x.OrderId == orderId && x.DeleteDate == null).ToList();

            var totalOrder = new TotalOrderResponse();
            totalOrder.TotalAnimals = orderAnimals.Sum(x => x.AnimalsAmount);
            totalOrder.TotalPrice = orderAnimals.Sum(x => x.TotalPerItem);

            return totalOrder;
        }

        public Order GetOrderInformation(Guid orderId)
        {
            var order = this._context.Orders.Where(x => x.OrderId == orderId && x.DeleteDate == null).FirstOrDefault();

            return order;
        }
    }
}
