using STGeneticsProject.Database;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Services
{
    public class OrderService
    {
        STGeneticsDBContext _context;

        public OrderService(STGeneticsDBContext context)
        {
            this._context = context;
        }
        public bool CreateOrder(Order request)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == request.AnimalId && x.DeleteDate == null).FirstOrDefault();

            var order = new Order();

            order.OrderId = Guid.NewGuid();
            order.AnimalId = request.AnimalId;
            order.AnimalsAmount = request.AnimalsAmount;

            var discount = checkDiscount();
            order.Discount = discount;

            order.Total = 3 + 4

            

            this._context.Orders.Add(order);
            this._context.SaveChanges();

            return true;
        }
    }
}
