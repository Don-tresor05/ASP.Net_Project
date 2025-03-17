using Microsoft.AspNetCore.Mvc;

namespace Simple_Login.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
