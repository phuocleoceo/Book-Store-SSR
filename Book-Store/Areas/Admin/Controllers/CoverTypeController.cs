using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Book_Store.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Read
        public IActionResult Index()
        {
            var data = _unitOfWork.CoverType.GetAll();
            return View(data);
        }
        #endregion

        #region Update + Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            // Create
            if (id == null)
            {
                return View(coverType);
            }
            // Edit
            coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault()); //value or null
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                if (coverType.Id == 0)
                {
                    _unitOfWork.CoverType.Add(coverType);
                }
                else
                {
                    _unitOfWork.CoverType.Update(coverType);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var deleteCT = _unitOfWork.CoverType.Get(id);
            if (deleteCT == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(deleteCT);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
