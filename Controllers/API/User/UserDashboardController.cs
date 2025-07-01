using Microsoft.AspNetCore.Mvc;

namespace app_example.Controllers.API.User
{
    public class UserDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
