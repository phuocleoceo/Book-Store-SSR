using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Read
        public IActionResult Index()
        {
            var data = _unitOfWork.Company.GetAll();
            return View(data);
        }
        #endregion

        #region Update + Insert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Company company = new Company();
            // Create
            if (id == null)
            {
                return View(company);
            }
            // Edit
            company = _unitOfWork.Company.Get(id.GetValueOrDefault()); //value or null
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(company);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var deleteCompany = _unitOfWork.Company.Get(id);
            if (deleteCompany == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(deleteCompany);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
