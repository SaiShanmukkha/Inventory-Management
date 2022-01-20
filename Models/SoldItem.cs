using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class SoldItem
    {
        public int SoldItemsId { get; set; }
        public string ItemName { set; get; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public int SellOrderID { get; set; }
        public string SellInvoiceNumber { get; set; }
    }
}
