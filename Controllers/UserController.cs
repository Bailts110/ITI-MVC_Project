using ITI_Final_Project.Context;
using ITI_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Final_Project.Controllers
{
    public class UserController : Controller
    {
        E_CommerceContext _CommerceContext=new E_CommerceContext();
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _CommerceContext.Users.Add(user);
                _CommerceContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _CommerceContext.Users.SingleOrDefault(e => e.Email == email && e.Password == password);
            if (user != null)
            {
                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login");
            return View();
        }
    }
}
