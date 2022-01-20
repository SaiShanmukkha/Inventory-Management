using CloudCart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderStatus(int purchasrOrderId)
        {
            ViewBag.purchasrOrderId = purchasrOrderId;
            return View();
        }
    }
}
