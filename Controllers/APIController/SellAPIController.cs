using CloudCart.Models;
using CloudCart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Controllers.APIController
{
    [Route("api/sell")]
    [ApiController]
    public class SellAPIController : ControllerBase
    {
        [HttpPost("OrderAction")]
        public IActionResult OrderAction(SellOrder sellOrder)
        {
            sellOrder.SellDate = DateTime.Now;
            sellOrder.SellTransactionID = sellOrder.SellInvoiceNumber;
            int recoredId = SellService.Process_Sell_Order(sellOrder);
            if (recoredId > 0)
            {
                return Ok(recoredId);
            }
            return BadRequest();
        }
    }
}
