using Microsoft.AspNetCore.Mvc;
using racing_webApp.Data;

namespace racing_webApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly Db_context _context;

        public ClubController(Db_context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var clubs=_context.Clubs.ToList();
            return View(clubs);
        }
    }
}
