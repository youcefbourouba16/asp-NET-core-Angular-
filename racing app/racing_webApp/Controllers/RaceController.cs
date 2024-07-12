using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Data.Enum;
using racing_webApp.Extensions;
using racing_webApp.Inerfaces;
using racing_webApp.Models;
using racing_webApp.Repository;
using racing_webApp.Servicess;
using racing_webApp.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace racing_webApp.Controllers
{
    public class RaceController : Controller
    {
        
        private readonly IRaceRepo _raceRepo;
        private readonly IphotoService _photoService;

        public RaceController(IRaceRepo raceRepo,IphotoService photoSertvices)
        {
            _raceRepo = raceRepo;
            _photoService = photoSertvices;
        }
        public async Task<IActionResult> Index()
        {
            var Races =await _raceRepo.GetAll();
            return View(Races);
        }

        public class RaceViewModel 
        {
            public Race Race { get; set; }
            public List<Race> RelatedRaces { get; set; }
        }
        public async  Task<IActionResult> Details(int ID)
        {

            var race =await _raceRepo.GetByIdAsyc(ID);
            var races =await _raceRepo.GetAll();
            var relatedClubs =races
                                .Where(c => c.Id != ID && (c.RaceCategory ==race.RaceCategory || c.Address == race.Address)) // Exclude the current club
                                .Take(8) 
                                .ToList();

            var viewModel = new RaceViewModel
            {
                Race = race,
                RelatedRaces = relatedClubs 
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            string userId = HttpContext.User.GetUserIDAccessor();

            CreateRaceViewModel vm = new CreateRaceViewModel()
            {

                AppUserId = userId
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel vm)
        {

            
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _photoService.AddphotoAsync(vm.Image);
            
            var race = new Race
            {
                Title = vm.Title,
                Description = vm.Description,
                Image = result.Url.ToString(),
                RaceCategory = vm.RaceCategory,
                AppUserId = vm.AppUserId,
                StartTime = vm.StartTime,
                EntryFee = vm.EntryFee,
                Website = vm.Website,
                Twitter = vm.Twitter,
                Facebook=vm.Facebook,
                Contact=vm.Contact,
                Address = new Address
                {
                    Street = vm.Address.Street,
                    City = vm.Address.City,
                    State = vm.Address.State,
                }
            };
            _raceRepo.Add(race);
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            Race vm = await _raceRepo.GetByIdAsyc(id);

            var viewModel = new EditRaceViewModel
            {
                Id=vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                ImageUrl = vm.Image,
                RaceCategory = vm.RaceCategory,
                AppUserId = vm.AppUserId,
                StartTime = vm.StartTime,
                EntryFee = vm.EntryFee,
                Website = vm.Website,
                Twitter = vm.Twitter,
                Facebook = vm.Facebook,
                Contact = vm.Contact,
                Address = new Address
                {
                    Street = vm.Address.Street,
                    City = vm.Address.City,
                    State = vm.Address.State,
                }
            };

            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRaceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var race = new Race
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                RaceCategory = vm.RaceCategory,
                AppUserId = vm.AppUserId,
                StartTime = vm.StartTime,
                EntryFee = vm.EntryFee,
                Website = vm.Website,
                Twitter = vm.Twitter,
                Facebook = vm.Facebook,
                Contact = vm.Contact,
                Address = new Address
                {
                    Street = vm.Address.Street,
                    City = vm.Address.City,
                    State = vm.Address.State,
                }
            };
            if (vm.Image != null)
            {
                try
                {
                    var result = await _photoService.AddphotoAsync(vm.Image);
                    _photoService.DeletephotoAsync(vm.ImageUrl);
                    race.Image = result.Url.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            else
            {
                race.Image = vm.ImageUrl;
            }
            _raceRepo.Update(race);

            return RedirectToAction("Index");


        }
    }
}
