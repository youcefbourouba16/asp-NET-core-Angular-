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
                .Include(i => i.Sizes)     // Assuming Size is a navigation property
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
            var products = await _productRepo.GetAllProductViewModelsAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/Product/getProductDetails/{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductDetailsByID(int id)
        {
            //List<Color> colors = await _context.ItemColors
            //            .Where(ic => ic.ItemID == id)
            //            .Join(
            //                _context.Colors,
            //                ic => ic.ColorId,
            //                c => c.Name,
            //                (ic, c) => c
            //            )
            //            .ToListAsync();



            //List<Size> sizes = await _context.ItemSizes
            //            .Where(ic => ic.ItemID == id)
            //            .Join(
            //                _context.Sizes,
            //                ic => ic.SizeID,
            //                c => c.Name,
            //                (ic, c) => c
            //            )
            //            .ToListAsync();
            var product = await _context.Items
            .Where(p => p.Id == id)
            .Include(p => p.ProductType)
            .Include(p => p.Colors)
                .ThenInclude(ic => ic.Color) // Navigate to the Color entity, not ColorId
            .Include(p => p.Sizes)
            .Select(p => new ProductDetails
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Sizes = p.Sizes.Select(s => new Size
                {
                    Name = s.SizeID // Assuming SizeID represents the size identifier or name
                }).ToList(),
                Colors = p.Colors.Select(c => new Color
                {
                    Name = c.Color.Name, // Navigate to the Color's Name property
                    HexValue = c.Color.HexValue // Include other properties if needed
                }).ToList(),
                Quantity = p.Quantity,
                Price = p.Price,
                ImageURL = p.ImageURL,
                productTypeId = p.ProductType.typeName, // Assuming ProductType has a property TypeName
                Category = p.Category
            })
            .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
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
                .Where(c => vm.Size.Contains(c.Name))
                .ToList();
            ProductType productTypeItem = _context.ProductTypes.FirstOrDefault(c => c.typeName == vm.ProductTypeId);
            
            var item = new Item
            {
                Name = vm.Name,
                Description = vm.Description,
                Quantity = vm.Quantity,
                Price = vm.Price,
                ImageURL = result.Url.ToString(),
                productTypeId = vm.ProductTypeId,
                Category = vm.Category.ToString(),
                ProductType = productTypeItem
            };
            
            _productRepo.Add(item);
            _productRepo.AddItemColors(colors, item.Id);
            _productRepo.AddItemSizes(sizes, item.Id);

            return Ok(item);  // Return the created item as the response
        }

        [HttpGet]
        [Route("api/Product/getProductByCategory/{categoryName}")]
        public async Task<ActionResult<ProductDetails>> getProductByCategory(string categoryName)
        {
            var products = await _context.Items
                .Where(p => p.Category == categoryName)
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Id = p.Id,
                    Category = p.Category,
                    Price = p.Price,
                    ImageURL = p.ImageURL
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("api/Product/getProductBySizes/")]
        public async Task<ActionResult<ProductViewModel>> getProductByCategory(List<string> Sizes)
        {

            var items =await _productRepo.GetItemsBySizesAsync(Sizes);
            return Ok(items);
        }


        [HttpGet]
        [Route("api/Product/getProductByColor/{colorName}")]
        public async Task<ActionResult<ProductViewModel>> getProductByColor(string colorName)
        {
            var items = await _productRepo.GetItemsByColorAsync(colorName);
            return Ok(items);
        }

    }
}
