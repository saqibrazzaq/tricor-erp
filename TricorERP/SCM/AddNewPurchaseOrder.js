// Initializing operations
$(document).ready(function () {

    $(".ItemRowEdit2").click(function () {
        ItemRow_onClick2($(this));
    });
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
            $(".DeleteStockItem").trigger("click");
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
    var ProductID = row.find(".ItemCol_ProductID").text();
    var quantity = row.find(".ItemCol_Quantity").text().trim();
    var price = row.find(".ItemCol_Price").text().trim();
    var RecivedQuantity = row.find(".ItemCol_RecivedQuantity").text().trim();
    $("#PurchaseOrderLabel").text("Update Items of ProductCode# (" + ProductID + ")");
    $(".txtQuantity").val(quantity);
    $(".txtPrice").val(price);
    
    $(".txtRecivedQuantity").val(RecivedQuantity);
    $(".txtPurchaseOrderItemID").val(itemID);
}
function ItemRow_onClick2(arg) {
    initializeItemModalDialog2();

    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    var ProductID = row.find(".ItemCol_ProductID").text();
    var quantity = row.find(".ItemCol_Quantity").text().trim();
    var RecivedQuantity = row.find(".ItemCol_RecivedQuantity").text().trim();

    $("#PurchaseOrderLabel").text("Update Items of ProductCode## (" + ProductID + ")");
    $(".txtQuantity").val(quantity);
    $(".txtRecivedQuantity").val(RecivedQuantity);
    $(".txtPurchaseOrderItemID").val(itemID);
}

function initializeItemModalDialog() {
    $("#PurchaseOrderLabel").text("Update");
    $(".txtQuantity").val("0");
    $(".txtPrice").val("0");
    $(".txtRecivedQuantity").val("2");

}
function initializeItemModalDialog2() {
    $("#PurchaseOrderLabel").text("Update");
    $(".txtQuantity").val("0");
    $(".txtRecivedQuantity").val("1");

}

function ItemRowDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    $(".txtPurchaseOrderItemID").val(itemID);
}

