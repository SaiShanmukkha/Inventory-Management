using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Controllers
{
    public class SellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult OrderStatus(int sellOrderId)
        {
            ViewBag.sellOrderId = sellOrderId;
            return View();
        }
    }
}
