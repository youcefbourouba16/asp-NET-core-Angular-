using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.Models.order;
using ShopingApi.ViewModels;
using ShopingApi.ViewModels.Product;
using System.Security.Claims;

namespace ShopingApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly Db_Context _context;
        private readonly IPhotoService _photoService;
        private readonly IOrderRepo _orderRepo;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(Db_Context db_Context, IPhotoService photoService, IOrderRepo orderRepo,
            UserManager<AppUser> userManager)
        {
            _context = db_Context;
            _orderRepo = orderRepo;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/Order/PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest("Order is null.");
            }

            try
            {
                
                // Map the ViewModel to the Order model
                if (string.IsNullOrEmpty(vm.AspNetUsersId))
                {
                    var guestUser = await _userManager.FindByNameAsync("Guest");
                    vm.AspNetUsersId = guestUser?.Id; // Assign the guest user ID
                }
                Order order = new Order
                {
                    Id = vm.Id,
                    AspNetUsersId = vm.AspNetUsersId,
                    OrderDate = vm.OrderDate,
                    Total_Amount = vm.TotalAmount,  // Ensure property name consistency
                    Note = vm.Note,
                    OrderItems = vm.OrderItems?.Select(item => new OrderItem
                    {
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        OrderId=vm.Id,
                        
                    }).ToList()
                };

                // Create Shipping details
                Shipping shippingDetails = new Shipping
                {
                    OrderId = vm.Id,
                    State = vm.ShippingDetails?.State,
                    Postal_code = vm.ShippingDetails?.PostalCode,
                    Country = vm.ShippingDetails?.Country,
                    phone = vm.ShippingDetails?.Phone,
                    EmailAdress = vm.ShippingDetails?.EmailAddress
                };

                // Add Order and Shipping Details
                _orderRepo.AddOrder(order);
                _orderRepo.AddShipping(shippingDetails);

                // Return success response
                return Ok(new { message = "Order placed successfully!", orderId = Guid.NewGuid() });
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                // _logger.LogError(ex, "Error placing order");

                // Return error response
                return StatusCode(500, new { message = "An error occurred while placing the order.", error = ex.Message });
            }
        }


    }
}
