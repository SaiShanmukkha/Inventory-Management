using CloudCart.Models;
using CloudCart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Controllers.APIController
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseAPIController : ControllerBase
    {
        [HttpPost("OrderAction")]
        public IActionResult OrderAction(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.PurchaseDate = DateTime.Now;
            purchaseOrder.PurchaseTransactionID = purchaseOrder.PurchaseInvoiceNumber;
            int recoredId = PurchaseService.Process_Purchase_Order(purchaseOrder);
            if(recoredId>0)
            {
                return Ok(recoredId);
            }
            return BadRequest();
        }
    }
}
