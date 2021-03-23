using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Book_Store.Models.ViewModels;
using Book_Store.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Book_Store.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value, includeProperties: "Product")
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
                                                        .GetFirstOrDefault(c => c.Id == claim.Value, includeProperties: "Company");

            foreach (var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = cart.Product.Price;  //Price is not mapped so we need caculator it
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);

                cart.Product.Description = SD.ConvertToRawHtml(cart.Product.Description);

                //Only show maxLengthDes of Description
                int maxLengthDes = 100;
                if (cart.Product.Description.Length > maxLengthDes)
                {
                    cart.Product.Description = cart.Product.Description.Substring(0, maxLengthDes - 1) + "...";
                }
            }

            return View(ShoppingCartVM);
        }

        public IActionResult Plus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart
                        .GetFirstOrDefault(c => c.Id == cartId, includeProperties: "Product");

            cart.Count++;
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart
                        .GetFirstOrDefault(c => c.Id == cartId, includeProperties: "Product");
            if (cart.Count == 1)
            {
                var count = _unitOfWork.ShoppingCart
                            .GetAll(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count();

                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionShoppingCart, count - 1);
            }
            else
            {
                cart.Count--;
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart
                        .GetFirstOrDefault(c => c.Id == cartId, includeProperties: "Product");

            var count = _unitOfWork.ShoppingCart
                        .GetAll(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count();

            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.SessionShoppingCart, count - 1);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value, includeProperties: "Product")
            };
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
                    .GetFirstOrDefault(c => c.Id == claim.Value,includeProperties:"Company");

            foreach (var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = cart.Product.Price;  //Price is not mapped so we need caculator it
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.District = ShoppingCartVM.OrderHeader.ApplicationUser.District;
            ShoppingCartVM.OrderHeader.ProvinceOrCity = ShoppingCartVM.OrderHeader.ApplicationUser.ProvinceOrCity;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;

            return View(ShoppingCartVM);
        }
    }
}
