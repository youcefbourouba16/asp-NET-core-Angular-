using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Models;

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
        public class ClubViewModel
        {
            public Club Club { get; set; }
            public List<Club> RelatedClubs { get; set; } // Add this property
        }
        public IActionResult Details(int ID)
        {

            var club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == ID);

            // Fetch related clubs (This is just a sample. Adjust the logic as per your requirement)
            var relatedClubs = _context.Clubs
                                .Where(c => c.Id != ID && (c.ClubCategory==club.ClubCategory || c.Address==club.Address)) // Exclude the current club
                                .Take(8) // Fetch 4 related clubs
                                .ToList();

            var viewModel = new ClubViewModel
            {
                Club = club,
                RelatedClubs = relatedClubs // Set the related clubs
            };

            return View(viewModel);
        }
    }
}
