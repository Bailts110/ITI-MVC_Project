using ITI_Final_Project.Context;
using ITI_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Final_Project.Controllers
{
    public class ProductController : Controller
    {
        E_CommerceContext _CommerceContext=new E_CommerceContext();
        
        public IActionResult Index()
        {
            var products = _CommerceContext.Products.Include(e => e.Category).ToList();
            return View(products);
        }

        
        public IActionResult Details(int id)
        {
            var product = _CommerceContext.Products.Include(e => e.Category).FirstOrDefault(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_CommerceContext.Categories, "Id", "Name");
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _CommerceContext.Products.Add(product);
                _CommerceContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_CommerceContext.Categories, "Id", "Name");
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _CommerceContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_CommerceContext.Categories, "Id", "Name");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _CommerceContext.Products.Update(product);
                _CommerceContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_CommerceContext.Categories, "Id", "Name");
            return View(product);
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _CommerceContext.Products.Find(id);
            if (product != null)
            {
                _CommerceContext.Products.Remove(product);
                _CommerceContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
