using Book_Store.Data.Repository.IRepository;
using Book_Store.Models;
using Book_Store.Models.ViewModels;
using Book_Store.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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

                //byte[] utf = Encoding.Default.GetBytes(cart.Product.Description);
                //cart.Product.Description = SD.ConvertToRawHtml(Encoding.UTF8.GetString(utf));
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
    }
}
