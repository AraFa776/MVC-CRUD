using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;

namespace UsersApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<Users> _userManager;

        public HomeController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            ViewBag.UserRole = User.IsInRole("Admin") ? "Admin" : "User";
            ViewBag.UserName = user?.FullName ?? User.Identity.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}