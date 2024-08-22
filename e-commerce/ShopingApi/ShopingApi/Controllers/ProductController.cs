using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.ViewModels;
using ShopingApi.ViewModels.Product;
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
                .Include(i => i.Size)     // Assuming Size is a navigation property
                .Include(i => i.Colors)   // Assuming Colors is a navigation property
                .Include(i => i.ProductType) // Include the ProductType if it's a navigation property
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
            
            List<Color> colors = _context.Colors
                .Where(c => vm.Colors.Contains(c.Name))
                .ToList();

            List<Size> sizes = _context.Sizes
                .Where(c => vm.Size.Contains(c.size))
                .ToList();
            var item = new Item
            {
                Name = vm.Name,
                Description = vm.Description,
                Size = sizes,
                Colors = colors,
                Quantity = vm.Quantity,
                Price = vm.Price,
                ImageURL = result.Url.ToString(),
                productTypeId=vm.ProductTypeId,
                Category = vm.Category.ToString(),
            };
            
            _productRepo.Add(item);
            _productRepo.AddItemColors(colors, item.Id);
            _productRepo.AddItemSizes(sizes, item.Id);

            return Ok(item);  // Return the created item as the response
            }
            [HttpPost]
            [Route("api/Product/COlors")]
            public async Task<IActionResult> Create([FromForm] List<Color> vm)
            {
            

                return Ok(vm);  // Return the created item as the response
            }


    }
}
