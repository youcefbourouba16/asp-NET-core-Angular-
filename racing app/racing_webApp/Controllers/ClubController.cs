using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Inerfaces;
using racing_webApp.Models;
using racing_webApp.ViewModels;

namespace racing_webApp.Controllers
{
    public class ClubController : Controller
    {
        
        private readonly IClubRepo _clubRepo;
        private readonly IphotoService _photoService;

        public ClubController(IClubRepo clubRepo, IphotoService photoService)
        {
            
            _clubRepo = clubRepo;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var clubs= await _clubRepo.GetAll();
            return View(clubs);
        }
        public class ClubViewModel
        {
            public Club Club { get; set; }
            public List<Club> RelatedClubs { get; set; } // Add this property
        }
        public async Task<IActionResult> Details(int ID)
        {

            var club = await _clubRepo.GetByIdAsyc(ID);
            var clubs =await _clubRepo.GetAll();
            // Fetch related clubs (This is just a sample. Adjust the logic as per your requirement)
            var relatedClubs = clubs
                                .Where(c => c.Id != ID && (c.ClubCategory == club.ClubCategory || c.Address == club.Address)) // Exclude the current club
                                .Take(8) // Fetch 4 related clubs
                                .ToList();

            var viewModel = new ClubViewModel
            {
                Club = club,
                RelatedClubs = relatedClubs // Set the related clubs
            };

            return View(viewModel);
        }

        public  IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _photoService.AddphotoAsync(vm.Image);

            var club = new Club
            {
                Title = vm.Title,
                Description = vm.Description,
                Image = result.Url.ToString(),
                ClubCategory = vm.ClubCategory,
                AppUserId = vm.AppUserId,
                Address = new Address
                {
                    Street = vm.Address.Street,
                    City = vm.Address.City,
                    State = vm.Address.State,
                }
            };
            _clubRepo.Add(club);
            return RedirectToAction("Index");

        }
    }
}
