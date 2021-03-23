using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ShippingDate { get; set; }

        public float OrderTotal { get; set; }

        public string TrackingNumber { get; set; }

        public string Carrier { get; set; }

        public string PaymentStatus { get; set; }

        public string OrderStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime PaymentDueDate { get; set; }

        public string TransactionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string ProvinceOrCity { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
