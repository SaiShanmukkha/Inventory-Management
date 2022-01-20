using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class PurchaseOrder
    {
        public int? PurchaseOrderID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double PurchaseTotalPrice { get; set; }
        public string PurchaseInvoiceNumber {get; set;}
        public string PurchaseTransactionID {get; set;}
        public double PurchaseCourierCharge {get; set;}
        public string PurchaseItems { get; set; }
    }
}
