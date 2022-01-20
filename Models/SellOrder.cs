using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class SellOrder
    {
        public int? SellOrderID { get; set; }
        public DateTime? SellDate { get; set; }
        public string CustomerName { get; set; }
        public long CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public double SellTotalPrice { get; set; }
        public string SellInvoiceNumber { get; set; }
        public string SellTransactionID { get; set; }
        public double SellCourierCharge { get; set; }
        public string SellItems { get; set; }
    }
}
