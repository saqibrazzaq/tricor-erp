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
            $(".DeleteProductCompositionItem").trigger("click");
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
    var quantity = row.find(".ItemCol_Quantity").text().trim();

    $("#PurchaseOrderLabel").text("Update Quantity of Rawmaterial");
    $(".txtQuantity").val(quantity);
   }

function initializeItemModalDialog() {
    $("#ProductCompositionLabel").text("Update");
    $(".txtQuantity").val("0");

}

function ItemRowDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    $(".txtProductCompositionItemID").val(itemID);
}

