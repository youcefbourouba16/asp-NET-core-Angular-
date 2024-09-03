using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopingApi.Data;
using ShopingApi.ViewModels.Product;

namespace ShopingApi.Controllers
{
    public class Color_SizeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Db_Context _context;
        public Color_SizeController(Db_Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/Product/getAllColors")]
        public async Task<ActionResult> GetAllColors()
        {
            var colors = await _context.Colors
                .ToListAsync();

            return Ok(colors);
        }
        [HttpGet]
        [Route("api/Product/getAllsize")]
        public async Task<ActionResult> GetProductsView()
        {

            var colors = await _context.Colors
                .ToListAsync();

            return Ok(colors);
        }

        [HttpPost]
        [Route("api/Product/postColors")]
        public async Task<ActionResult> postcolor(List<string> dskl)
        {

            

            return Ok(dskl);
        }
    }
}
