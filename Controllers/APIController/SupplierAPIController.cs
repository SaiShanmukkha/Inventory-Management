using CloudCart.Models;
using CloudCart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudCart.Controllers.APIController
{
    [Route("api/Supplier")]
    [ApiController]
    public class SupplierAPIController : ControllerBase
    {
        [HttpGet("get-Suppliers")]
        public IActionResult Get_Suppliers()
        {
            List<Supplier> SupplierList = SuppliersService.Get_Suppliers();
            return Ok(SupplierList);
        }

        [HttpGet("get-Supplier/{id}")]
        public IActionResult Get_Supplier_By_Id(int? id)
        {
            if (id <= 0 || id == null)
            {
                return Problem("Invalid Supplier Id");
            }
            Supplier Supplier = SuppliersService.Get_Supplier_By_Id(id);
            if(Supplier.SupplierId == -1)
            {
                return NotFound();
            }
            return Ok(Supplier);
        }

        [HttpPost("add-Supplier")]
        public IActionResult Add_Supplier(Supplier Supplier)
        {
            Supplier.SupplierDataLastUpdate = DateTime.Now;
            Supplier.SupplierJoinDate = DateTime.Now;
            Supplier.SupplierRating = 1.1;

            int rowsEffected = SuppliersService.Insert_Supplier(Supplier);
            if(rowsEffected == -1)
            {
                return Problem("Error Occurred");
            }
            return Ok("Created Supplier Successfully");
        }


        [HttpPost("update-Supplier")]
        public IActionResult Update_Supplier(Supplier Supplier)
        {
            Supplier.SupplierDataLastUpdate = DateTime.Now;

            int rowsEffected = SuppliersService.Update_Supplier(Supplier);
            if (rowsEffected == -1)
            {
                return Problem("Error Occurred while Updating.");
            }
            return Ok("updated Successfully");
        }

        



    }
}
