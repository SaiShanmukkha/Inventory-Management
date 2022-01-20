using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class PurchasedItem
    {
        public int PurchasedItemsId { get; set; }
        public string ItemName { set; get; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemSupplierId{get; set;}
        public int PurchaseOrderID{get; set;}
        public string PurchaseInvoiceNumber { get; set; }
    }
}
