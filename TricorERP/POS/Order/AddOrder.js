// Initializing operations
$(document).ready(function () {

    $(".ItemRowEdit").click(function () {
       
        ItemRow_onClick($(this));
    });

    $(".ItemRowDelete").click(function () {
        ItemRowDelete_onClick($(this));
    });
    
    $(".confirm").confirm({

        text: "Are you sure you want to delete?",
        title: "Delete",
        confirm: function (button) {
            $(".DeleteSalesOrder").trigger("click");
        },
        cancel: function (button) {
            // nothing to do
        },
        confirmButton: "Yes",
        cancelButton: "No",
        post: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-default"
    });
});

function ItemRow_onClick(arg) {
    initializeItemModalDialog();

    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    var productName = row.find(".ItemCol_ProductName").text();
    var quantity = row.find(".ItemCol_Quantity").text().trim();
    var price = row.find(".ItemCol_Price").text().trim();

    $("#SalesOrderLabel").text("Update Items (" + productName + ")");
    $(".txtQuantity").val(quantity);
    $(".txtPrice").val(price);
    $(".txtSalesOrderItemID").val(itemID);
}

function initializeItemModalDialog() {
    $("#SalesOrderLabel").text("Update");
    $(".txtQuantity").val("0");
    $(".txtPrice").val("0");
}

function ItemRowDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    $(".txtSalesOrderItemID").val(itemID);
}

