using Microsoft.AspNetCore.Mvc;
using StoreBook.Repository.IRepository;
using StoreBook.Models;
using System.Collections.Generic;

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
    }
}
