using Microsoft.AspNetCore.Mvc;
using StoreBook.Repository.IRepository;
using StoreBook.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StoreBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> listOfProducts = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(listOfProducts);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork.CategoryRepository
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            ViewBag.CategoryList = categoryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var productName = _unitOfWork.ProductRepository.Get(n => n.Title == product.Title);
            var productISBN = _unitOfWork.ProductRepository.Get(n => n.ISBN == product.ISBN);

            if (productName != null)
            {
                ModelState.AddModelError(key: "Title", errorMessage: "This title already exist");
            }
            if(productISBN != null)
            {
                ModelState.AddModelError(key: "ISBN", errorMessage: "This ISBN already exist");
            }
            if(product.Title == product.ISBN)
            {
                ModelState.AddModelError(key: "Title", errorMessage: "The title cannot exatly match the ISBN");
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product has been created successfully";
                return RedirectToAction(actionName: "Index", controllerName: "Product");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            Product product = _unitOfWork.ProductRepository.Get(n => n.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var comparerProduct = _unitOfWork.ProductRepository.Get(n => n.ISBN == product.ISBN ||
            n.Title == product.Title);
            if(comparerProduct != null)
            {
                ModelState.AddModelError(key: "Title", errorMessage: "Such etity is already exist");
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product has been updated successfully";
                return RedirectToAction(actionName: "Index", controllerName: "Product");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Product p = _unitOfWork.ProductRepository.Get(u => u.Id == product.Id);
            if(p == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Remove(p);
            _unitOfWork.Save();
            TempData["success"] = "Product has been deleted successfully";
            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

    }
}
