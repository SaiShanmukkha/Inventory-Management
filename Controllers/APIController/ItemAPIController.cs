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
    [Route("api/item")]
    [ApiController]
    public class ItemAPIController : ControllerBase
    {

        [HttpPost("add-item")]
        public IActionResult Add_Item(Item item)
        {
            item.ItemQuantity = 0;
            item.ItemCreationDate = DateTime.Now;
            item.ItemLastUpdate = DateTime.Now;

            int rowsEffected = ItemsService.InsertItem(item);
            if(rowsEffected == 1){
                return Ok("Item Added Sucessfully");
            }
            return Problem("Failed to Add Item");
            
        }

        [HttpPost("update-item")]
        public IActionResult Update_Item(Item item)
        {
            Item oldItem = ItemsService.Get_Item_By_Id(item.ItemId);
            if(oldItem.ItemId == -1){
                return Problem("Item Not Found to Update");
            }
            item.ItemQuantity = oldItem.ItemQuantity;
            item.ItemCreationDate = oldItem.ItemCreationDate;
            item.ItemLastUpdate = DateTime.Now;

            int rowsEffected = ItemsService.UpdateItem(item);
            if(rowsEffected == 1){
                return Ok("Item Updated Sucessfully");
            }
            return Problem("Failed to Update Item");
            
        }

    
        [HttpGet("get-items")]
        public IActionResult Get_Items(){
            List<Item> items = ItemsService.GetItems();
            return Ok(items);
        }


        [HttpGet("get-item/{id}")]
        public IActionResult Get_Item_By_ID(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            Item item = ItemsService.Get_Item_By_Id(id);
            if(item.ItemId == -1){
                return Problem("Item Not Found to Update");
            }
            return Ok(item);
        }
    
        [HttpDelete("delete-item/{id}")]
        public IActionResult Delete_Item(int id){
            if(id <= 0 ){
                return Problem("Invalid Id");
            }
            Item item = ItemsService.Get_Item_By_Id(id);
            if(item.ItemId == -1){
                return Problem("Item Not Found to Delete");
            }
            int rowsEffected = ItemsService.Deleteitem(item.ItemId);
            if(rowsEffected != 1){
                return Problem("Failed to delete item");
            }
            return Ok();
        }

    }
}