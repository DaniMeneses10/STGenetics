using Microsoft.AspNetCore.Mvc;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService _orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public ActionResult<bool> CreateOrder(Order order)
        {
            return this._orderService.CreateOrder(order);
        }
    }
}
