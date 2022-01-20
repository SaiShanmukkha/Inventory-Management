using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;
using CloudCart.Models;
using CloudCart.Services;

namespace CloudCart.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {           
            List<PurchaseOrder> purchaseOrders = PurchaseService.GetRecentOrders();
            ViewBag.purchaseRecentOrders = purchaseOrders;

            List<SellOrder> sellOrders = SellService.GetRecentOrders();
            ViewBag.sellRecentOrders = sellOrders;
            return View();
        }

        
    }
}
