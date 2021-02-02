using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
