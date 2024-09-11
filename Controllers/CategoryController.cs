using ITI_Final_Project.Context;
using ITI_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Final_Project.Controllers
{
    public class CategoryController : Controller
    {
        E_CommerceContext _CommerceContext=new E_CommerceContext();
        public IActionResult Index()
        {
            return View(_CommerceContext.Categories.ToList());
        }

        
        public IActionResult Details(int id)
        {
            var category = _CommerceContext.Categories.Include(e => e.Products).FirstOrDefault(e => e.Id == id);
            return View(category);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            ModelState.Remove("Products");
            if (ModelState.IsValid)
            {
                _CommerceContext.Categories.Add(category);
                _CommerceContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _CommerceContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ModelState.Remove("Products");
            if (ModelState.IsValid)
            {
                _CommerceContext.Categories.Update(category);
                _CommerceContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

       
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _CommerceContext.Categories.Find(id);
            if (category != null)
            {
                _CommerceContext.Categories.Remove(category);
                _CommerceContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
