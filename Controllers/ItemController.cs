using CloudCart.Models;
using CloudCart.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            List<Item> itemList = ItemsService.GetItems();
            ViewBag.Items = itemList;
            return View();
        }

    }
}
