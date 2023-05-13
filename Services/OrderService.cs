using Azure.Core;
using STGeneticsProject.Database;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;
using STGeneticsProject.Models.Responses;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace STGeneticsProject.Services
{
    public class OrderService : IOrderService
    {
        STGeneticsDBContext _context;

        public OrderService(STGeneticsDBContext context)
        {
            this._context = context;
        }
        public Order CreateNewOrder(Order request)
        {
            var newOrder = new Order();
            newOrder.OrderId = Guid.NewGuid();
            newOrder.CreateDate = DateTime.UtcNow;

            this._context.Orders.Add(newOrder);
            this._context.SaveChanges();

            return newOrder;
        }

        public ItemDetails AddNewItem(OrderDetailsRequest request)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == request.AnimalId && x.DeleteDate == null).FirstOrDefault();
            var order = this._context.Orders.Where(x => x.OrderId == request.AnimalId && x.DeleteDate == null).FirstOrDefault();            
            var orderDetails = this._context.OrdersDetails.Where(x => x.OrderId == request.OrderId && x.DeleteDate == null).ToList();
            var orderAnimals = orderDetails.Where(x => x.AnimalId == request.AnimalId && x.DeleteDate == null).ToList();
            
            if (orderAnimals.Any())
                throw new ValidationException("The animal already exists in the order, you can´t add more than once");

            var newItem = new ItemDetails();

            newItem.OrderDetailsId = Guid.NewGuid();
            newItem.OrderId = request.OrderId;
            newItem.AnimalId = request.AnimalId;
            newItem.PricePerUnit = animal.Price;
            newItem.AnimalsAmount = request.AnimalsAmount;
            newItem.CreateDate = DateTime.UtcNow;

            var total = CalculateTotalWithDiscount(animal.Price, request.AnimalsAmount);
            newItem.TotalPerItem = total;

            this._context.OrdersDetails.Add(newItem);
            this._context.SaveChanges();


            Task.Run(() =>
            {
                CalculateTotalOrder(request.OrderId);
            });

            return newItem;
        }

        public double CalculateTotalWithDiscount(double animalPrice, double animalsAmount)
        {
            double totalPurchasePrice = animalsAmount * animalPrice;

            double discount = 0.0;
            double freightCharge = 1000.0;

            if (animalsAmount > 300)
            {
                freightCharge = 0.0;
                if (animalsAmount > 200)
                {
                    discount += 0.03;
                    if (animalsAmount > 50)
                    {
                        discount += 0.05;
                    }
                }
            }
            else if (animalsAmount > 200)
            {
                discount += 0.03;
                if (animalsAmount > 50)
                {
                    discount += 0.05;
                }
            }
            else if (animalsAmount > 50)
            {
                discount += 0.05;
            }

            double totalDiscount = totalPurchasePrice * discount;
            
            double finalPurchasePrice = totalPurchasePrice - totalDiscount + freightCharge;

            return finalPurchasePrice;
        }

        public Order GetOrderInformation(Guid orderId)
        {
            var order = this._context.Orders.Where(x => x.OrderId == orderId && x.DeleteDate == null).FirstOrDefault();

            return order;
        }

        public void CalculateTotalOrder(Guid orderId)
        {
            var orderDetails = this._context.OrdersDetails.Where(x => x.OrderId == orderId && x.DeleteDate == null).ToList();
            orderDetails.Sum(x => x.TotalPerItem);

            this._context.SaveChanges();
        }

    }
}
