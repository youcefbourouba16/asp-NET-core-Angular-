using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Data.Enum;
using racing_webApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace racing_webApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly Db_context _context;

        public RaceController(Db_context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Races = _context.Races.ToList();
            return View(Races);
        }

        public class RaceViewModel 
        {
            public Race Race { get; set; }
            public List<Race> RelatedRaces { get; set; } // Add this property
        }
        public IActionResult Details(int ID)
        {

            var race = _context.Races.Include(a => a.Address).FirstOrDefault(c => c.Id == ID);

            // Fetch related clubs (This is just a sample. Adjust the logic as per your requirement)
            var relatedClubs = _context.Races
                                .Where(c => c.Id != ID && (c.RaceCategory ==race.RaceCategory || c.Address == race.Address)) // Exclude the current club
                                .Take(8) // Fetch 4 related clubs
                                .ToList();

            var viewModel = new RaceViewModel
            {
                Race = race,
                RelatedRaces = relatedClubs // Set the related clubs
            };

            return View(viewModel);
        }
    }
}
