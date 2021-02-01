using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
