using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Book_Store.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Book_Store.Utility;
using Microsoft.AspNetCore.Authorization;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        private readonly BSContext _db;

        public UserController(BSContext db)
        {
            _db = db;
        }

        #region Read
        public IActionResult Index()
        {
            var userList = _db.ApplicationUsers.Include(c => c.Company).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                // SELECT * FROM userList 
                // INNER JOIN UserRoles on userList.Id = UserRoles.UserId
                // INNER JOIN Roles on Roles.Id = UserRoles.RoleId
                var roleId = userRole.FirstOrDefault(c => c.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(c => c.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            return View(userList);
        }
        #endregion

        //#region Update + Insert
        //[HttpGet]
        //public IActionResult Upsert(int? id)
        //{
        //    Category category = new Category();
        //    // Create
        //    if (id == null)
        //    {
        //        return View(category);
        //    }
        //    // Edit
        //    category = _unitOfWork.Category.Get(id.GetValueOrDefault()); //value or null
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (category.Id == 0)
        //        {
        //            _unitOfWork.Category.Add(category);
        //        }
        //        else
        //        {
        //            _unitOfWork.Category.Update(category);
        //        }
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}
        //#endregion

        //#region Delete
        //public IActionResult Delete(int id)
        //{
        //    var deleteCategory = _unitOfWork.Category.Get(id);
        //    if (deleteCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Category.Remove(deleteCategory);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}
        //#endregion
    }
}