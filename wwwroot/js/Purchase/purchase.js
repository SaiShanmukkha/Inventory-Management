$(document).ready(function () {
  // Generating Invoice Number
  assignInvoiceNumber();
  fetchItems();
  fetchSuppliers();
  generateCartTable();

  $("#confirm-purchase").click(function () {
    var purchaseCartItems = localStorage.getItem("purchaseCartItems");
    if (purchaseCartItems != null) {
      var isPurchaseConfirmed = confirm("Are you really confirm Purchase?");
      if (isPurchaseConfirmed) {
        var itemTotalPrice = $("#PurchaseTotalPrice").val();
        let invoiceNumber = $("#PurchaseInvoiceNumber").val();
        let carrierCharge = $("#PurchaseCourierCharge").val();

          var data = {
              "PurchaseTotalPrice": parseFloat(itemTotalPrice),
              "PurchaseInvoiceNumber": invoiceNumber,
              "PurchaseCourierCharge": parseFloat(carrierCharge),
              "PurchaseItems": purchaseCartItems
          };

        $.ajax({
          type: "post",
            url: "api/purchase/OrderAction",
            contentType:"application/json",
            data: JSON.stringify(data),
          success: async function (response) {
            $.notify("Order Confirmed","success");
            localStorage.removeItem("purchaseCartItems")
            await new Promise(resolve => setTimeout(resolve, 1500));
            $.redirect("/purchase/orderstatus",{"purchasrOrderId":response},'POST');
          },
          error: function(response){
            $.notify("Error occurred in placing order","danger");
          }
        });

      }
    } else {
        $.notify("No Items in Cart to Purchase","info");
    }
   });
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
  var itemTotalPrice =
    parseFloat($("#ItemPrice").val()) * parseInt($("#ItemQuantity").val());
  itemTotalPrice = Math.round(itemTotalPrice * 100) / 100;
  $("#ItemTotalPrice").val(itemTotalPrice);
});

function assignInvoiceNumber() {
  var dt = Date.now();
  var result = "";
  var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
  var charactersLength = characters.length;
  for (var i = 0; i < 6; i++) {
    result += characters.charAt(Math.floor(Math.random() * charactersLength));
  }
  $("#PurchaseInvoiceNumber").val(
    result.substring(0, 3) + dt.toString() + result.substring(3, 6)
  );
}

function fetchItems() {
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

function fetchSuppliers() {
  $.ajax({
    type: "get",
    url: "/api/Supplier/get-Suppliers",
    success: function (response) {
      $.each(response, function (index) {
        $("#ItemSupplier").append(
          new Option(
            response[index]["supplierName"],
            JSON.stringify([
              response[index]["supplierId"],
              response[index]["supplierName"],
            ])
          )
        );
      });
    },
  });
}

function addToCartCall() {
  if (itemSelectionValid()) {
    let itemData = JSON.parse($("#ItemName").val());
    let supplierData = JSON.parse($("#ItemSupplier").val());
    let item = {
      ItemId: itemData["itemId"],
      ItemName: itemData["itemName"],
      ItemQuantity: parseInt($("#ItemQuantity").val()),
      ItemPrice: parseFloat(itemData["itemPrice"]),
      ItemSupplierId: parseInt(supplierData[0]),
      ItemSupplierName: supplierData[1],
    };

    var purchaseCartItems = localStorage.getItem("purchaseCartItems");
    if (purchaseCartItems != null) {
      var purchaseCartItemsData = JSON.parse(purchaseCartItems);
    } else {
      var purchaseCartItemsData = [];
    }
    purchaseCartItemsData.push(item);
    localStorage.setItem(
      "purchaseCartItems",
      JSON.stringify(purchaseCartItemsData)
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
    let supplierData = $("#ItemSupplier").val();
    let itemQuantity = parseInt($("#ItemQuantity").val());
    if (itemData != "null" && supplierData != "null" && itemQuantity > 0) {
      return true;
    }
  } catch (e) {
    console.log("Error occurred" + e);
  }
  return false;
}

function emptyCartCall() {
  if (localStorage.getItem("purchaseCartItems")) {
    let isConfirmed = confirm("Are you really want to Empty Cart?");
    if (isConfirmed) {
      localStorage.removeItem("purchaseCartItems");
      $.notify("Cart Emptied","success");
      generateCartTable();
      $("#PurchaseTotalPrice").val(0);
    }
  } else {
    $.notify("No Items in Cart to Delete", "info");
  }
}

function generateCartTable() {
  var purchaseCartItems = localStorage.getItem("purchaseCartItems");
  if (purchaseCartItems != null) {
    var grandTotalPrice = 0;
    var purchaseCartItemsData = JSON.parse(purchaseCartItems);
    var cartTable = `<table class="table table-active table-hovered">
    <thead>
        <th>Item Name</th>
        <th>Item Price</th>
        <th>Item Supplier</th>
        <th>Item Quantity</th>
        <th>Item Total Price</th>
    </thead>
    <tbody>`;
    purchaseCartItemsData.forEach((item) => {
      console.log(item);
      var itemTotalPrice =
        parseInt(item["ItemQuantity"]) * parseFloat(item["ItemPrice"]);
      itemTotalPrice = Math.round(itemTotalPrice * 100) / 100;
      grandTotalPrice += itemTotalPrice;
      cartTable += `<tr><td>${item["ItemName"]}</td><td>${item["ItemPrice"]}</td><td>${item["ItemSupplierName"]}</td><td>${item["ItemQuantity"]}</td><td>${itemTotalPrice}</td></tr>`;
    });
    cartTable += `</tbody></table>`;
    $(".cart-table").html(cartTable);
    $("#PurchaseTotalPrice").val(grandTotalPrice);
  } else {
    $(".cart-table").html("<p>No Items in Cart</p>");
  }
}

