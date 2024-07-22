using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using racing_webApp.Inerfaces;
using racing_webApp.Models;
using racing_webApp.Repository;
using racing_webApp.ViewModels;

namespace racing_webApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo) {
            _userRepo= userRepo;
        }
        [Route("runners")]
        public async Task<IActionResult> Index()
        {
            var User=await _userRepo.GetAllUsers();//youcef
            List<UserViewModel> VMs = new List<UserViewModel>();
            foreach (var item in User)
            {
                UserViewModel VM=new UserViewModel(){
                    id=item.Id,
                    Pace=item.Pace ?? 0,
                    UserName=item.UserName,
                    Milleage=item.Mileage ?? 0
                };
                VMs.Add(VM);

            }
            return View(VMs);
        }
        public async Task<IActionResult> Details(string id)
        {
            var user= await _userRepo.GetUserById(id);
            UserDetailViewModel vm = new UserDetailViewModel()
            {
                id=user.Id,
                UserName=user.UserName,
                Milleage=user.Mileage,
                Pace=user.Pace
            };
            return View(vm);
        }
    }
}
