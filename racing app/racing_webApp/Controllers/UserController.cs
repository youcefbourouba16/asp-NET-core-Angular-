using Microsoft.AspNetCore.Mvc;
using racing_webApp.Inerfaces;
using racing_webApp.Repository;
using racing_webApp.ViewModels;

namespace racing_webApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        UserController(IUserRepo userRepo) {
            _userRepo= userRepo;
        }
        [Route("runners")]
        public async Task<IActionResult> Index()
        {
            var User=await _userRepo.GetAllUsers();
            List<UserViewModel> VMs = new List<UserViewModel>();
            foreach (var item in User)
            {
                UserViewModel VM=new UserViewModel(){
                    id=item.Id,
                    Pace=item.Pace ?? 0,
                    UserName=item.UserName,
                    Milleage=item.Mileage ?? 0
                };

            }
            return View();
        }
    }
}
