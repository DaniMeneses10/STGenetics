using Microsoft.AspNetCore.Mvc;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        [Route("CreateNewOrder")]
        public ActionResult<Order> CreateNewOrder(NewOrderRequest order)
        {
            return this._orderService.CreateNewOrder(order);
        }

        [HttpGet]
        [Route("GetOrderInformation")]
        public ActionResult<Order> GetOrderInformation(Guid orderId)
        {
            return this._orderService.GetOrderInformation(orderId);
        }
    }
}
