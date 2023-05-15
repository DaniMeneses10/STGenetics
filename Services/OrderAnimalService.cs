using STGeneticsProject.Database;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Services
{
    public class OrderAnimalService : IOrderAnimalService
    {
        STGeneticsDBContext _context;        

        public OrderAnimalService(STGeneticsDBContext context)
        {
            this._context = context;            
        }

        public bool CreateAnimalOrderDetails(OrderDetailsRequest request)
        {
            var animals = request.AnimalsList;
            var orderId = request.OrderId;

            foreach (var item in animals)
            {
                var animal = this._context.Animals.Where(x => x.AnimalId == item.AnimalId && x.DeleteDate == null).FirstOrDefault();

                var orderAnimal = new OrderAnimal();
                orderAnimal.OrderAnimalId = Guid.NewGuid();
                orderAnimal.OrderId = orderId;
                orderAnimal.AnimalId = item.AnimalId;
                orderAnimal.PricePerUnit = animal.Price;
                orderAnimal.AnimalsAmount = item.AnimalsAmount;
                orderAnimal.TotalPerItem = CalculateTotalWithDiscount(animal.Price, item.AnimalsAmount);
                orderAnimal.CreateDate = DateTime.UtcNow;
                orderAnimal.DeleteDate = null;

                this._context.OrdersAnimals.Add(orderAnimal);               
            }

            this._context.SaveChanges();
            return true;
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


    }
}
