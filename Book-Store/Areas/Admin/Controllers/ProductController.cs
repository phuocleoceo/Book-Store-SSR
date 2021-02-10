using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Book_Store.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Book_Store.Utility;
using Microsoft.AspNetCore.Authorization;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Read
        public IActionResult Index()
        {
            var data = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            return View(data);
        }
        #endregion

        #region Update + Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            //SelectListItem khi render sẽ thành <option></option>
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            // Create
            if (id == null)
            {
                return View(productVM);
            }
            // Edit
            productVM.Product = _unitOfWork.Product.Get(id.GetValueOrDefault()); //value or null
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(productVM);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var deleteProduct = _unitOfWork.Product.Get(id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(deleteProduct);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #endregion
    }
}