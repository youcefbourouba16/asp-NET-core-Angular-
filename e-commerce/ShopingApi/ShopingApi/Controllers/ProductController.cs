using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.ViewModels;
using System.Net;

namespace ShopingApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly Db_Context _context;
        private readonly IPhotoService _photoService;
        private readonly IProductRepo _productRepo;

        public ProductController(Db_Context db_Context,IPhotoService photoService, IProductRepo productRepo)
        {
            _context = db_Context;
            _photoService = photoService;
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Product/getProduct")]
        public async Task<ActionResult<IEnumerable<Item>>> GetProducts()
        {

            var items = await _context.Items
                 .Include(i => i.Category)    
                 .ToListAsync();
            if (items == null || !items.Any())
            {
                return NoContent(); // Returns 204 No Content
            }
            return Ok(items);
            
        }

        [HttpGet]
        [Route("api/Product/getProductView")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsView()
        {
            var products = await _context.Items
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Id=p.Id,
                    Category=p.Category,
                    Price = p.Price,
                    ImageURL=p.ImageURL
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        [Route("api/Product/CreateProduct")]
        public async Task<IActionResult> Create([FromForm] CreateProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Changed View to BadRequest for API response
            }

            var result = await _photoService.AddphotoAsync(vm.Image);

            var item = new Item
            {
                Name = vm.Name,
                Description = vm.Description,
                Size = vm.Size,
                Colors = vm.Colors,
                Quantity = vm.Quantity,
                Price = vm.Price,
                ImageURL = result.Url.ToString(),
                productTypeId=vm.ProductTypeId,
                Category = vm.Category
            };

            _productRepo.Add(item);

            return Ok(item);  // Return the created item as the response
        }


    }
}
