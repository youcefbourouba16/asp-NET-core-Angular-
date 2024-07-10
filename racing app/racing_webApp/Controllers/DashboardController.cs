using Microsoft.AspNetCore.Mvc;
using racing_webApp.Data;
using racing_webApp.Inerfaces;
using racing_webApp.Models;
using racing_webApp.ViewModels;

namespace racing_webApp.Controllers
{
    public class DashboardController : Controller
    {
        
        private readonly IDashboardRepo _dashboardRepo;

        public DashboardController(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }
        public async Task<IActionResult> Index()
        {
            var userlubs=await _dashboardRepo.GetAllUserClubs();
            var userRaces  =await _dashboardRepo.GetAllUserRaces();
            DashboardViewModel VM = new DashboardViewModel()
            {
                Clubs=userlubs,
                Races=userRaces,
            };
            return View(VM);
        }
    }
}
