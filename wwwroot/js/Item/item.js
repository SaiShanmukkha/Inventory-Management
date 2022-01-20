$(document).ready(function () {

    $("#Add-item-modal-call").click(function () { 
        $("#itemNameEr").hide();
        $("#itemPriceEr").hide();        
    });

    $("#AddItem-form-Submit").click(function () { 
        if(Add_Item_Validation()){
            var data = {
                itemName : $("#ItemName").val(),
                itemPrice : $("#ItemPrice").val()
            };
            $.ajax({
                type: "post",
                url: "/api/item/Add-item",
                contentType:"application/json",
                data: JSON.stringify(data),
                success: async function (response) {
                    $.notify("Added Successfully","success");
                    $("#addItemModal").modal('hide');
                    await new Promise(resolve => setTimeout(resolve, 1500));
                    location.reload();
                },
                error: function(response){
                    $.notify("Failed to Add Item");
                }
            });
        }
        
    });

    $('#addItemModal').on('hidden.bs.modal', function () {
        $(this).find('form').trigger('reset');
    });

    $('#updateItemModal').on('hidden.bs.modal',function(){
        localStorage.removeItem('Item');
    });

    

});

function deleteItemCall(item){
    if(confirm(`Are you really want to delete item?\nItem Id : ${item[0]}\nItem Name : ${item[1]}`)){
        $.ajax({
            type: "delete",
            url: `/api/item/delete-item/${item[0]}`,
            success: async function (response) {
                $.notify("Item Delete Successfully","success");
                await new Promise(resolve => setTimeout(resolve, 1500));
                location.reload();
            },
            error: function(response){
                $.notify("Failed to update Item","danger");
            }
        });
    }
}



function UpdateItemCall(){
    var itemName = $("#UpdateItemName").val();
    var itemPrice = $("#UpdateItemPrice").val();
    var itemId = $("#UpdateItemID").val();
    var item = [itemId, itemName, itemPrice];
    if (isChangeOccured(item)){
        if(Update_Item_Validation()){
            var data = {
                itemId : itemId,
                itemName : itemName,
                itemPrice : itemPrice
            };
            $.ajax({
                type: "post",
                url: "/api/item/update-item",
                contentType:"application/json",
                data: JSON.stringify(data),
                success: async function (response) {
                    $.notify("Item Updated Successfully","success");
                    $("#updateItemModal").modal('hide');
                    localStorage.removeItem("Item");
                    await new Promise(resolve => setTimeout(resolve, 1500));
                    location.reload();
                },
                error: function(response){
                    $.notify("Failed to update Item");
                }
            });
        }

    }else{
        $.notify("No Changes Made", "warning");
    }
}


function isChangeOccured(newItem){
    var oldItem = localStorage.getItem("Item").split(",");
    if(newItem[1]==oldItem[1] && newItem[2]==oldItem[2]){
        return false;
    }
    return true;
}



function Add_Item_Validation(){
    let itemName = $("#ItemName").val();
    let itemPrice = $("#ItemPrice").val();
    var valid = true;
    
    if(itemName.trim() == "" || null){
        $("#itemNameEr").show();
        valid = false;
    }else{
        $("#itemNameEr").hide();   
    }


    if(itemPrice.trim() == "" || null){
        $("#itemPriceEr").show();  
        valid = false;      
    }else if( parseFloat(itemPrice) == NaN){
        $("#itemPriceEr").show();  
        valid = false;
    }else if(parseFloat(itemPrice) < 0){
        $("#itemPriceEr").show();  
        valid = false;
    }   
    else{
        $("#itemPriceEr").hide();   
    }

    return valid;
}

function Update_Item_Validation(){
    let itemName = $("#UpdateItemName").val();
    let itemPrice = $("#UpdateItemPrice").val();
    var valid = true;
    
    if(itemName.trim() == "" || null){
        $("#updateItemNameEr").show();
        valid = false;
    }else{
        $("#updateItemNameEr").hide();   
    }


    if(itemPrice.trim() == "" || null){
        $("#updateItemPriceEr").show();  
        valid = false;      
    }else if( parseFloat(itemPrice) == NaN){
        $("#updateItemPriceEr").show();  
        valid = false;
    }else if(parseFloat(itemPrice) < 0){
        $("#updateItemPriceEr").show();  
        valid = false;
    }   
    else{
        $("#updateItemPriceEr").hide();   
    }

    return valid;
}



function viewUpdateModal(Item){
    localStorage.setItem("Item",Item);
    $("#updateItemNameEr").hide();
    $("#updateItemPriceEr").hide();  
    $("#UpdateItemID").val(Item[0]);
    $("#UpdateItemName").val(Item[1]);
    $("#UpdateItemPrice").val(Item[2]);
    $("#updateItemModal").modal('show');
}
