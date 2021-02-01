using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Read
        public IActionResult Index()
        {
            var data = _unitOfWork.Category.GetAll();
            return View(data);
        }
        #endregion

        #region Update + Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            // Create
            if (id == null)
            {
                return View(category);
            }
            // Edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault()); //value or null
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var deleteCategory = _unitOfWork.Category.Get(id);
            if (deleteCategory == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(deleteCategory);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
