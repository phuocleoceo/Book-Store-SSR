using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Book_Store.Models.ViewModels;
using Book_Store.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Book_Store.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value)
                            .ToList().Count();

                HttpContext.Session.SetInt32(SD.SessionShoppingCart, count);
            }
            
            return View(productList);
        }

        #region DetailsAndCart
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id, includeProperties: "Category,CoverType");
            ShoppingCart cart = new ShoppingCart()
            {
                Product = product,
                ProductId = product.Id
            };
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            cart.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDB = _unitOfWork.ShoppingCart.GetFirstOrDefault(c =>
                  c.ApplicationUserId == cart.ApplicationUserId && c.ProductId == cart.ProductId, includeProperties: "Product");

                //no record exists in database for that product for that user
                if (cartFromDB == null)
                {
                    _unitOfWork.ShoppingCart.Add(cart);
                }
                else
                {
                    cartFromDB.Count += cart.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDB);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == cart.ApplicationUserId)
                            .ToList().Count();

                //HttpContext.Session.SetObject(SD.SessionShoppingCart,count);
                HttpContext.Session.SetInt32(SD.SessionShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productFromDB = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == cart.ProductId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productFromDB,
                    ProductId = productFromDB.Id
                };
            }
            return View(cart);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
