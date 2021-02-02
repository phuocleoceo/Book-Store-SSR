using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1000,10000000)]
        public float ListPrice { get; set; }

        [Required]
        [Range(1000, 10000000)]
        public float Price { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }
    }
}
