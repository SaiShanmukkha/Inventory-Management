using CloudCart.Models;
using CloudCart.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudCart.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            string url = @$"{this.Request.Scheme}://{this.Request.Host}/api/Supplier/get-Suppliers";
            IEnumerable<Supplier> obj = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var data = reader.ReadToEnd();
            obj = JsonSerializer.Deserialize<List<Supplier>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewBag.Suppliers = obj;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier Supplier)
        {
            string url = @$"{this.Request.Scheme}://{this.Request.Host}/api/Supplier/add-Supplier";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            var jsonData = JsonSerializer.Serialize(Supplier);
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var data = reader.ReadToEnd();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Some Error Occurred");
        }

        [HttpGet]
        public IActionResult Update(int? id )
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }
            Supplier Supplier = SuppliersService.Get_Supplier_By_Id(id);
            if (Supplier.SupplierId == -1)
            {
                return NotFound();
            }
            return View(Supplier);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            Supplier Supplier = SuppliersService.Get_Supplier_By_Id(id);
            if (Supplier.SupplierId == -1)
            {
                return NotFound();
            }
            return View(Supplier);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            return RedirectToAction("Index");
        }
        
    }
}
