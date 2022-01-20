using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class Supplier
    {
        [Key]
        [DisplayName("Supplier Id")]
        public int? SupplierId { get; set; }

        [Required]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        [Required]
        [DisplayName("Supplier Industry")]
        public string SupplierIndustry { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Supplier Email")]
        public string SupplierEmail { get; set; }
        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Enter a Valid 10 digit Contact Number")]
        [DisplayName("Supplier Phone")]
        public long SupplierPhone { get; set; }
        [Required]
        [DisplayName("Supplier Address")]
        public string SupplierAddress { get; set; }

        [DisplayName("Supplier Join Date")]
        public DateTime? SupplierJoinDate { get; set; }

        [DisplayName("Supplier Rating")]
        public double SupplierRating { get; set; }
        [Required]
        [DisplayName("Supplier City")]
        public string SupplierCity { get; set; }
        [Required]
        [DisplayName("Supplier Province")]
        public string SupplierProvince { get; set; }
        [Required]
        [DisplayName("Supplier Country")]
        public string SupplierCountry { get; set; }
        [Required]
        [DisplayName("Supplier Pin Code")]
        public int SupplierPinCode { get; set; }

        [DisplayName("Supplier Last Updated")]
        public DateTime? SupplierDataLastUpdate { get; set; }

    }
}
