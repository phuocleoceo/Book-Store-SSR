using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }

        public OrderHeader OrderHeader { get; set; }

    }
}
