using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Book_Store.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string District { get; set; }

        public string ProvinceOrCity { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAuthorizedCompany { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}
