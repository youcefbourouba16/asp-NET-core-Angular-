using Microsoft.AspNetCore.Mvc;
using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.ViewModels;
using ShopingApi.ViewModels.Product;

namespace ShopingApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly Db_Context _context;
        private readonly IPhotoService _photoService;
        private readonly IOrderRepo _orderRepo;

        public OrderController(Db_Context db_Context, IPhotoService photoService, IOrderRepo orderRepo)
        {
            _context = db_Context;
            _orderRepo = orderRepo;
        }

        [HttpPost]
        [Route("api/Order/PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderViewModel order)
        {
            if (order == null)
            {
                return BadRequest("Order is null.");
            }

            return Ok(new { message = "Order placed successfully!", orderId = Guid.NewGuid() });
        }

    }
}
