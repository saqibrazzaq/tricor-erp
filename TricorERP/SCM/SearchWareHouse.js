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
            $(".DeletePurchaseOrder").trigger("click");
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

    $("#PurchaseOrderLabel").text("Update Items of ProductCode# (" + ProductID + ")");
    $(".txtQuantity").val(quantity);
    $(".txtPrice").val(price);
    $(".txtPurchaseOrderItemID").val(itemID);
}

function initializeItemModalDialog() {
    $("#PurchaseOrderLabel").text("Update");
    $(".txtQuantity").val("0");
    $(".txtPrice").val("0");

}

function ItemRowDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    $(".txtPurchaseOrderItemID").val(itemID);
}

