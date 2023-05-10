using Microsoft.AspNetCore.Mvc;
using StoreBook.Data;
using StoreBook.Models;
using StoreBook.Repository.IRepository;

namespace StoreBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var categoryName = _unitOfWork.CategoryRepository.Get(n => n.Name == category.Name);
            var categoryDisplayOrder = _unitOfWork.CategoryRepository.Get(d => d.DisplayOrder == category.DisplayOrder);
            if(categoryName != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This name is already exist");
            }
            if(categoryDisplayOrder != null)
            {
                ModelState.AddModelError(key: "DisplayOrder", errorMessage: "This order is already exist");
            }
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(key: "Name", errorMessage: "The Display order cannot exatly match the name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category has been created successfully";
                return RedirectToAction(actionName: "Index", controllerName: "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var comparer = _unitOfWork.CategoryRepository.Get(n => n.Name == category.Name || n.DisplayOrder == category.DisplayOrder);
            if(comparer != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This category is already with such name or order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category has been edited successfully";
                return RedirectToAction(actionName: "Index", controllerName: "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == 0 || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.CategoryRepository.Get(i => i.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _unitOfWork.CategoryRepository.Get(i => i.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category has been deleted successfully";
            return RedirectToAction(actionName: "Index", controllerName: "Category");
        }
    }
}
