using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Models
{
    public class Item
    {
        public int? ItemId{get; set;}
        public string ItemName{get; set;}
        public int? ItemQuantity{get; set;}
        public double ItemPrice{get; set;}
        public DateTime? ItemCreationDate{get; set;}
        public DateTime? ItemLastUpdate{get; set;}
    }
}
