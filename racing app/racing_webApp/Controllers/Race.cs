using Microsoft.AspNetCore.Mvc;
using racing_webApp.Data;

namespace racing_webApp.Controllers
{
    public class Race : Controller
    {
        private readonly Db_context _context;

        public Race(Db_context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Races = _context.Races.ToList();
            return View(Races);
        }
    }
}
