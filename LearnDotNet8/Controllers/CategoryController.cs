using LearnDotNet8.Data;
using LearnDotNet8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnDotNet8.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public CategoryController(ApplicationDbContext db) {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() { 
            return View(); }    
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.CategoryName == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound(); 
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
         
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? item = _db.Categories.Find(id);

            if (item == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(item);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
