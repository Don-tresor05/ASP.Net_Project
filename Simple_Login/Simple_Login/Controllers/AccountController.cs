using Microsoft.AspNetCore.Mvc;
using Simple_Login.Models;

namespace Simple_Login.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic (e.g., save to database) goes here
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Authentication logic (e.g., verify user credentials) goes here
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
