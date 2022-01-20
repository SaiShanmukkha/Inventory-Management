$(document).ready(function () {
  generateInvoiceNumber();
  fetchItems();
  generateCartTable();
});


$("#confirm-sell").click(function () {
    var sellCartItems = localStorage.getItem("sellCartItems");
    let customerName = $("#CustomerName").val();
    let customerEmail = $("#CustomerEmail").val();
    let customerPhone = parseInt($("#CustomerPhone").val());
    if(customerName.trim() != "" && customerEmail.trim() != "" && customerPhone != ""){
    if (sellCartItems != null) {
      var isSellConfirmed = confirm("Are you really buy Items in cart?");
      if (isSellConfirmed) {
        let itemsTotalPrice = $("#sellTotalPrice").val();
        let invoiceNumber = $("#SellInvoiceNumber").val();
        let carrierCharge = $("#SellCourierCharge").val();
        

          var data = {
              "CustomerName":customerName,
              "CustomerPhone":parseInt(customerPhone),
              "CustomerEmail":customerEmail,
              "SellTotalPrice": parseFloat(itemsTotalPrice),
              "SellInvoiceNumber": invoiceNumber,
              "SellCourierCharge": parseFloat(carrierCharge),
              "SellItems": sellCartItems
          };

        $.ajax({
          type: "post",
            url: "api/sell/OrderAction",
            contentType:"application/json",
            data: JSON.stringify(data),
          success: async function (response) {
            $.notify("Order Confirmed","success");
            localStorage.removeItem("sellCartItems");
            await new Promise(resolve => setTimeout(resolve, 1500));
            $.redirect("/sell/orderstatus",{"sellOrderId":response},'POST');
          },
          error: function(response){
            $.notify("Error occurred in placing order","danger");
          }
        });

      }
    } else {
        $.notify("No Items in Cart to Purchase","info");
    }}else{
        $.notify("Enter Customer Data fields");   
    }
   });





$("#ItemQuantity").change(function () {
    var itemTotalPrice =
      parseFloat($("#ItemPrice").val()) * parseInt($("#ItemQuantity").val());
    itemTotalPrice = Math.round(itemTotalPrice * 100) / 100;
    $("#ItemTotalPrice").val(itemTotalPrice);
  });
  
  $(document).on("change", "#ItemName", function () {
    var itemData = JSON.parse($("#ItemName").val());
    $("#ItemPrice").val(itemData["itemPrice"]);
    $("#ItemStock").val(itemData["itemQuantity"]);
    var itemTotalPrice =
      parseFloat($("#ItemPrice").val()) * parseInt($("#ItemQuantity").val());
    itemTotalPrice = Math.round(itemTotalPrice * 100) / 100;
    $("#ItemTotalPrice").val(itemTotalPrice);
  });





function fetchItems(){
    $.ajax({
        type: "get",
        url: "/api/item/get-items",
        success: function (response) {
          $.each(response, function (index) {
            $("#ItemName").append(
              new Option(
                response[index]["itemName"],
                JSON.stringify(response[index])
              )
            );
          });
        },
      });
}

function addToCartCall() {
    if (itemSelectionValid()) {
      let itemData = JSON.parse($("#ItemName").val());
      let item = {
        ItemId: itemData["itemId"],
        ItemName: itemData["itemName"],
        ItemQuantity: parseInt($("#ItemQuantity").val()),
        ItemPrice: parseFloat(itemData["itemPrice"]),
      };
  
      var sellCartItems = localStorage.getItem("sellCartItems");
      if (sellCartItems != null) {
        var sellCartItemsData = JSON.parse(sellCartItems);
      } else {
        var sellCartItemsData = [];
      }
      sellCartItemsData.push(item);
      localStorage.setItem(
        "sellCartItems",
        JSON.stringify(sellCartItemsData)
      );
      generateCartTable();
      $.notify("Added to cart", "success");
    } else {
      $.notify("Incorrect Data", "warn");
    }
  }


function itemSelectionValid() {
    try {
      let itemData = $("#ItemName").val();
      let itemQuantity = parseInt($("#ItemQuantity").val());
      let stockAvailable = parseInt($("#ItemStock").val());

      if (itemData != "null" && itemQuantity > 0 && itemQuantity <= stockAvailable) {
        return true;
      }
    } catch (e) {
      console.log("Error occurred" + e);
    }
    return false;
  }


function generateInvoiceNumber() {
  var dt = Date.now();
  var result = "";
  var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
  var charactersLength = characters.length;
  for (var i = 0; i < 6; i++) {
    result += characters.charAt(Math.floor(Math.random() * charactersLength));
  }
  $("#SellInvoiceNumber").val(
    result.substring(0, 3) + dt.toString() + result.substring(3, 6)
  );
}


function emptyCartCall() {
    if (localStorage.getItem("sellCartItems")) {
      let isConfirmed = confirm("Are you really want to Empty Cart?");
      if (isConfirmed) {
        localStorage.removeItem("sellCartItems");
        $.notify("Cart Emptied","success");
        generateCartTable();
        $("#sellTotalPrice").val(0);
      }
    } else {
      $.notify("No Items in Cart to Delete", "info");
    }
  }

function generateCartTable(){
    var sellCartItems = localStorage.getItem("sellCartItems");
  if (sellCartItems != null) {
    var grandTotalPrice = 0;
    var sellCartItemsData = JSON.parse(sellCartItems);
    var cartTable = `<table class="table table-active table-hovered">
    <thead>
        <th>Item Name</th>
        <th>Item Price</th>
        <th>Item Quantity</th>
        <th>Item Total Price</th>
    </thead>
    <tbody>`;
    sellCartItemsData.forEach((item) => {
      var itemTotalPrice =
        parseInt(item["ItemQuantity"]) * parseFloat(item["ItemPrice"]);
      itemTotalPrice = Math.round(itemTotalPrice * 100) / 100;
      grandTotalPrice += itemTotalPrice;
      cartTable += `<tr><td>${item["ItemName"]}</td><td>${item["ItemPrice"]}</td><td>${item["ItemQuantity"]}</td><td>${itemTotalPrice}</td></tr>`;
    });
    cartTable += `</tbody></table>`;
    $(".cart-table").html(cartTable);
    $("#sellTotalPrice").val(grandTotalPrice);
  } else {
    $(".cart-table").html("<p>No Items in Cart</p>");
  }
}