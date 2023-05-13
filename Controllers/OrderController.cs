using Microsoft.AspNetCore.Mvc;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;
using STGeneticsProject.Models.Responses;

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
        public ActionResult<Order> CreateNewOrder(Order order)
        {
            return this._orderService.CreateNewOrder(order);
        }

        [HttpPost]
        [Route("AddNewItem")]
        public ActionResult<ItemDetails> AddNewItem(OrderDetailsRequest request)
        {
            return this._orderService.AddNewItem(request);
        }

        [HttpGet]
        [Route("GetOrderInformation")]
        public ActionResult<Order> GetOrderInformation(Guid orderId)
        {
            return this._orderService.GetOrderInformation(orderId);
        }
        


    }
}
