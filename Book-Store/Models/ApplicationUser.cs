using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string District { get; set; }

        public string ProvinceOrCity { get; set; }

        public string PostalCode { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
